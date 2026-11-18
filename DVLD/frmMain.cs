
using DVLD.Applications;
using DVLD.Classes;
using DVLD.Login; // ERROR: CS0234 - namespace 'Login' does not exist
using DVLD.People;
using DVLD.User;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace DVLD
{

    public partial class frmMain : Form
    {
        frmLogin _frmLogin;

        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            _frmLogin = frm;

        }


        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmAddUpdateLocalDrivingLicesnseApplication frm = new frmAddUpdateLocalDrivingLicesnseApplication(); // ERROR: CS0246 - type 'frmAddUpdateLocalDrivingLicesnseApplication' could not be found
            //frm.ShowDialog();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListPeople();
            frm.ShowDialog();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListUsers();
            frm.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            lblLoggedInUser.Text = "LoggedIn User: " + clsGlobal.CurrentUser.UserName;
            this.Refresh();

        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();

        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();

        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmListTestTypes frm = new frmListTestTypes(); // ERROR: CS0246 - type 'frmListTestTypes' could not be found
            //frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication(); // ERROR: CS0246 - type 'frmNewInternationalLicenseApplication' could not be found
            //frm.ShowDialog();

        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmRenewLocalDrivingLicenseApplication frm = new frmRenewLocalDrivingLicenseApplication(); // ERROR: CS0246 - type 'frmRenewLocalDrivingLicenseApplication' could not be found
            //frm.ShowDialog();

        }

       

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication(); // ERROR: CS0246 - type 'frmReleaseDetainedLicenseApplication' could not be found
            //frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmListLocalDrivingLicesnseApplications frm = new frmListLocalDrivingLicesnseApplications(); // ERROR: CS0246 - type 'frmListLocalDrivingLicesnseApplications' could not be found
            //frm.ShowDialog();
        }

      
        private void vehiclesLicensesServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void manageLocalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmListLocalDrivingLicesnseApplications frm = new frmListLocalDrivingLicesnseApplications(); // ERROR: CS0246 - type 'frmListLocalDrivingLicesnseApplications' could not be found
            //frm.ShowDialog();

        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmListDrivers frm = new frmListDrivers(); // ERROR: CS0246 - type 'frmListDrivers' could not be found
            //frm.ShowDialog();

        }

      

        private void ManageInternationaDrivingLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmListInternationalLicesnseApplications frm = new frmListInternationalLicesnseApplications(); // ERROR: CS0246 - type 'frmListInternationalLicesnseApplications' could not be found
            //frm.ShowDialog();

        }

        private void ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmReplaceLostOrDamagedLicenseApplication frm = new frmReplaceLostOrDamagedLicenseApplication(); // ERROR: CS0246 - type 'frmReplaceLostOrDamagedLicenseApplication' could not be found
            //frm.ShowDialog();

        }

        private void ManageDetainedLicensestoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmListDetainedLicenses frm = new frmListDetainedLicenses(); // ERROR: CS0246 - type 'frmListDetainedLicenses' could not be found
            //frm.ShowDialog();

        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //frmDetainLicenseApplication frm = new frmDetainLicenseApplication(); // ERROR: CS0246 - type 'frmDetainLicenseApplication' could not be found
           // frm.ShowDialog();

        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmReleaseDetainedLicenseApplication frm= new frmReleaseDetainedLicenseApplication(); // ERROR: CS0246 - type 'frmReleaseDetainedLicenseApplication' could not be found
            //frm.ShowDialog();

        }
    }
}
