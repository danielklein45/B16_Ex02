using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace FacebookSmartView
{
   [Serializable]
    class PictureObject : PictureObjectBasic 
    {
        // Private Properties
         [NonSerialized]
        private PictureBox m_PictureBox;
         [NonSerialized]
        private Label m_BottomLable;

        public PictureObject(string i_ObjectId, int i_NumberOfLikes, int i_NumberOfComments,
                            int i_Score, string i_PictureUrl, string i_DateCreated,
                            PictureBox i_PictureBox, Label i_InfoLableBottom)
            : base(i_ObjectId, i_NumberOfLikes, i_NumberOfComments, i_Score,
            i_PictureUrl, i_DateCreated)
        {
           SetGraphicProperties(i_PictureBox, i_InfoLableBottom);
        }

        public PictureObject(string i_ObjectId, int i_NumberOfLikes, int i_NumberOfComments,
                           int i_Score, string i_PictureUrl, string i_DateCreated)
            : base(i_ObjectId, i_NumberOfLikes, i_NumberOfComments, i_Score,
            i_PictureUrl, i_DateCreated)
        {
        }

        public void SetGraphicProperties(PictureBox i_PictureBox, Label i_InfoLableBottom){
             this.m_PictureBox = i_PictureBox;
            this.m_BottomLable = i_InfoLableBottom;
        }


        public void LoadInformation()
        {
            this.m_PictureBox.Load(this.PictureUrl);
            this.m_BottomLable.Text = String.Format("{0} Likes + {1} Comments = {2} Score", 
                this.NumberOfLikes, this.NumberOfComments, this.Score);
        }

       
    }
}
