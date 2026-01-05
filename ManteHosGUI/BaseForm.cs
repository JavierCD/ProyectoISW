using System.Windows.Forms;

namespace ManteHosGUI
{
    public class BaseForm : Form
    {

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.Manual;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.ResumeLayout(false);

        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void BaseForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}

