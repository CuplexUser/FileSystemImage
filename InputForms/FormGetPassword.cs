using System;
using System.Windows.Forms;
using GeneralToolkitLib.Converters;

namespace FileSystemImage.InputForms
{
    public partial class FormGetPassword : Form
    {
        public string PasswordDerivedString { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordString { get; private set; }
        public bool PasswordVerified { get; private set; }

        public FormGetPassword()
        {
            this.PasswordSalt = "";
            this.InitializeComponent();
            this.PasswordVerified = false;
        }

        private void FormGetPassword_Shown(object sender, EventArgs e)
        {
            this.txtPassword.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.HandleOkClick();}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.HandleCancelClick();
        }

        private void HandleOkClick()
        {
            if(PasswordDerivedString != null && this.PasswordDerivedString != GeneralConverters.GeneratePasswordDerivedString(this.PasswordSalt + this.txtPassword.Text + this.PasswordSalt))
            {
                MessageBox.Show(this, "Invalid password");
                return;
            }
            this.PasswordString = this.txtPassword.Text;
            this.PasswordVerified = true;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                this.HandleOkClick();
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == (char)Keys.Escape)
            {
                this.HandleCancelClick();
            }
        }

        private void HandleCancelClick()
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
