using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacebookSmartView
{
    public partial class FormFilterGroup : Form
    {

        public FilterGroup GroupFilter { get; set; }
        public FormFilterGroup()
        {
            InitializeComponent();
            GroupFilter = new FilterGroup();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            textBoxGroupName.Text = GroupFilter.Name;

            foreach (IFilter item in GroupFilter)
            {
                checkedListFilterItems.Items.Add(item);
            }
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {   
            if (!string.IsNullOrEmpty(textBoxFilterItem.Text))
            {
                FilterItem newItem = new FilterItem(textBoxFilterItem.Text);
                addItem(newItem);

                textBoxFilterItem.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Item Cannot be Empty");
            }    
        }

        private void buttonSaveAndClose_Click(object sender, EventArgs e)
        {
            string groupName = textBoxGroupName.Text;
            
            if (!string.IsNullOrEmpty(groupName))
            {
                GroupFilter.Name = groupName;
                this.Close();
            }
            else
            {
                MessageBox.Show("Group Name Cannot be Empty");
            }
        }

        private void buttonRemoveItems_Click(object sender, EventArgs e)
        {
            IFilter filterItem = (IFilter)checkedListFilterItems.SelectedItem;

            if (filterItem != null)
            {
                GroupFilter.RemoveItem(filterItem);
                checkedListFilterItems.Items.Remove(filterItem);
            }
            else
            {
                MessageBox.Show("At least one item must be selected");
            }
        }

        private void buttonAddInnerGroup_Click(object sender, EventArgs e)
        {
            FormFilterGroup innerForm = new FormFilterGroup();
            innerForm.ShowDialog();
            addItem(innerForm.GroupFilter);
        }

        private void addItem(IFilter i_Filter)
        {
            GroupFilter.AddItem(i_Filter);
            checkedListFilterItems.Items.Add(i_Filter);
        }

        private void checkedListFilterItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            IFilter filter = (IFilter)checkedListFilterItems.SelectedItem;
            if (filter != null)
            {
                textBoxFilterItem.Text = filter.ToString();
            }   
        }

        private void buttonEditItem_Click(object sender, EventArgs e)
        {
            IFilter filterItem = (IFilter)checkedListFilterItems.SelectedItem;
            FormFilterGroup innerForm = new FormFilterGroup();
            innerForm.GroupFilter = filterItem as FilterGroup;
            innerForm.ShowDialog();
        }
    }
}
