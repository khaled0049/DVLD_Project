using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Peolpe.Control
{
    public partial class ctrlUserCard : UserControl
    {
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        clsUser user = new clsUser();

        private void ctrlUserCard_Load(object sender, EventArgs e)
        {
           
        }

        private void _FillDataFromUserToCard(clsUser user)
        {
            lblUserID.Text += user.UserID.ToString();
            lblUserName.Text += user.UserName;
            if (user.IsActive == true)
            {
                lblIsActive.Text += " Active"; 
            }else
            {
                lblIsActive.Text += " Non Active";
            }
        }

        public void loadUserCard(int UserID)
        {
            user = clsUser.FindByUserID(UserID);

            if (user == null)
            {
                return; 
            }
            _FillDataFromUserToCard(user);

        }

        public void loadPersonInfo(int PersonID)
        {
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }
    }
}
