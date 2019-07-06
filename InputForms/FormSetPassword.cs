using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FileSystemImage.InputForms
{
    public partial class FormSetPassword : Form
    {
        string errorMessage;
        readonly Regex passwordPattern;
        public string VerifiedPassword { get; set; }

        public FormSetPassword()
        {
            this.InitializeComponent();
            this.passwordPattern = new Regex(@"^(?!.*\s)(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$");
            this.VerifiedPassword = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.TryToSetPassword();
        }

        private bool ValidatePasswords()
        {
            this.errorMessage=null;
            if (this.txtPassword1.Text != this.txtPassword2.Text)
                this.errorMessage = "Passwords did not match!";
            else if (this.txtPassword1.Text.Length < 8)
                this.errorMessage = "Password needs to bee atleast 8 characters long";
            else if (!this.passwordPattern.IsMatch(this.txtPassword1.Text))
                this.errorMessage = "Password did not mach the required complexity or did contain illegal characters like whitespaces.";

            return this.errorMessage == null;
        }

        private void txtPassword1_Enter(object sender, EventArgs e)
        {
            this.txtPassword1.SelectAll();
        }

        private void txtPassword2_Enter(object sender, EventArgs e)
        {
            this.txtPassword2.SelectAll();
        }

        private void txtPasswordFields_KeyUp(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Enter && this.txtPassword1.Text.Length > 0 && this.txtPassword2.Text.Length > 0)
            {
                e.Handled = true;
            }
        }

        private void txtPasswordFields_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.txtPassword1.Text.Length > 0 && this.txtPassword2.Text.Length > 0)
            {
                e.Handled = true;
                this.TryToSetPassword();
            }
        }

        private void TryToSetPassword()
        {
            if (!this.ValidatePasswords())
            {
                MessageBox.Show(this.errorMessage);
            }
            else
            {
                this.VerifiedPassword = this.txtPassword1.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


    }
}
