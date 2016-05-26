using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacebookSmartView
{
    class PictureObjectPrototypeFactory : CloneClass<PictureObject>
    {
        private PictureObject m_pictureObjectPrototype;

        private static PictureObjectPrototypeFactory s_CurrentInstance;
        private static Object s_LockOnMgt = new object();

        private PictureObjectPrototypeFactory()
        {
        }
       
        public static PictureObjectPrototypeFactory Instance
        {
            get
            {
                if (s_CurrentInstance == null)
                {
                    lock (s_LockOnMgt)
                    {
                        if (s_CurrentInstance == null)
                        {
                            s_CurrentInstance = new PictureObjectPrototypeFactory();
                        }
                    }
                }

                return s_CurrentInstance;
            }
        }


        public PictureObject GetPictureObjectBasic()
        {
            if (m_pictureObjectPrototype == null)
            {
                m_pictureObjectPrototype = createPictureBoxPrototype();
            }
            return DeepObjectClone(m_pictureObjectPrototype);
        }

        private PictureObject createPictureBoxPrototype()
        {
            return new PictureObject(string.Empty, 0, 0, 0, string.Empty, string.Empty);
        }

               
    }

   
}
