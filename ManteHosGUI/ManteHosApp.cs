using ManteHos.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ManteHosGUI
{
    public partial class ManteHosApp : BaseForm
    {

        //Creación de Componentes
        private IManteHosService s;
        private Panel panelLogin;
        private Panel panelIzquierdo;
        private Button btnMostrarPassword;
        private bool passwordVisible = false;
        private PictureBox iconoUsuario;

        public ManteHosApp()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;

            this.DoubleBuffered = true;

            InicializarUI();
        }

        public ManteHosApp(IManteHosService service)
        {
            InitializeComponent();
            s = service ?? throw new ArgumentNullException(nameof(service));
            
            this.AutoScaleMode = AutoScaleMode.None;
            this.DoubleBuffered = true;

            InicializarUI();
        }

        // ===============================
        // INICIALIZACIÓN GENERAL UI
        // ===============================
        private void InicializarUI()
        {
            CrearRectanguloIzquierdo();
            RedondearTextBox(UserBox);
            RedondearTextBox(PasswordBox);
            PasswordBox.UseSystemPasswordChar = true;
            RedondearBoton(LoginButton);
            CrearPanelLogin();

            this.Resize += (s, e) => CentrarPanelLogin();
        }

        // ===============================
        // PANEL LOGIN (MITAD DERECHA)
        // ===============================
        const int ICON_SIZE = 200;
        const int MARGIN_TOP = 10;
        const int SPACING = 20;
        const int ICON_GAP_SIZE = 40;
        const int ICON_GAP_MARGIN = 10;

        private PictureBox iconUser;
        private PictureBox iconPassword;


        private void CrearPanelLogin()
        {
            panelLogin = new Panel();
            panelLogin.Width = 360;
            panelLogin.BackColor = Color.Transparent;

            // ICONO USUARIO
            iconoUsuario = new PictureBox();
            iconoUsuario.Image = Image.FromFile("iconoUsuario.png");
            iconoUsuario.Size = new Size(ICON_SIZE, ICON_SIZE);
            iconoUsuario.SizeMode = PictureBoxSizeMode.Zoom;
            iconoUsuario.BackColor = Color.Transparent;

            iconoUsuario.Location = new Point(
                (panelLogin.Width - iconoUsuario.Width) / 2,
                MARGIN_TOP
            );

            panelLogin.Controls.Add(iconoUsuario);

            iconUser = new PictureBox();
            iconUser.Image = Image.FromFile("iconoUser.png");
            iconUser.Size = new Size(ICON_GAP_SIZE, ICON_GAP_SIZE);
            iconUser.SizeMode = PictureBoxSizeMode.Zoom;
            iconUser.BackColor = Color.Transparent;

            iconPassword = new PictureBox();
            iconPassword.Image = Image.FromFile("iconoContraseña.png");
            iconPassword.Size = new Size(ICON_GAP_SIZE-10, ICON_GAP_SIZE-10);
            iconPassword.SizeMode = PictureBoxSizeMode.Zoom;
            iconPassword.BackColor = Color.Transparent;

            // BOTÓN DB INIT
            btnDBIni.Location = new Point(
                (panelLogin.Width - btnDBIni.Width) / 2,
                LoginButton.Bottom + 150
            );
            panelLogin.Controls.Add(btnDBIni);

            // Layout dinámico
            int baseX = 45;
            int gapX = baseX + ICON_GAP_SIZE + ICON_GAP_MARGIN;

            // ICONO usado en USUARIO
            int y = iconoUsuario.Bottom + SPACING + 10;

            UserLabel.Location = new Point(baseX-20, y);
            y += UserLabel.Height + 5;

            iconUser.Location = new Point(
                baseX - 20,
                y
            );

            UserBox.Parent.Location = new Point(
                gapX-20,
                y
            );

            iconUser.Height = UserBox.Parent.Height;
            y += UserBox.Parent.Height + SPACING;

            // ICONO usado en CONTRASEÑA
            PasswordLabel.Location = new Point(baseX - 20, y);
            y += PasswordLabel.Height + 5;

            iconPassword.Location = new Point(
                baseX - 15,
                y
            );

            PasswordBox.Parent.Location = new Point(
                gapX - 20,
                y
            );

            iconPassword.Height = PasswordBox.Parent.Height;
            y += PasswordBox.Parent.Height + SPACING + 20;

            // BOTÓN LOGIN
            LoginButton.Location = new Point(
                (panelLogin.Width - LoginButton.Width) / 2,
                y
            );


            // BOTÓN MOSTRAR PASSWORD
            btnMostrarPassword = new Button();
            btnMostrarPassword.Size = new Size(32, 32);
            btnMostrarPassword.FlatStyle = FlatStyle.Flat;
            btnMostrarPassword.FlatAppearance.BorderSize = 0;
            btnMostrarPassword.BackColor = Color.Transparent;
            btnMostrarPassword.Cursor = Cursors.Hand;
            btnMostrarPassword.Text = "👁";
            btnMostrarPassword.Font = new Font("Segoe UI", 12);
            btnMostrarPassword.ForeColor = Color.Gray;

            btnMostrarPassword.Location = new Point(
                PasswordBox.Parent.Right + 5,
                PasswordBox.Parent.Top +
                (PasswordBox.Parent.Height - btnMostrarPassword.Height) / 2
            );

            btnMostrarPassword.Click += BtnMostrarPassword_Click;

            // Controles
            panelLogin.Controls.Add(UserLabel);
            panelLogin.Controls.Add(UserBox.Parent);
            panelLogin.Controls.Add(PasswordLabel);
            panelLogin.Controls.Add(PasswordBox.Parent);
            panelLogin.Controls.Add(LoginButton);
            panelLogin.Controls.Add(btnMostrarPassword);
            panelLogin.Controls.Add(iconUser);
            panelLogin.Controls.Add(iconPassword);


            // ALTURA AUTOMÁTICA DEL PANEL
            panelLogin.Height = btnDBIni.Bottom + MARGIN_TOP;

            this.Controls.Add(panelLogin);
            CentrarPanelLogin();
        }

        // EVENTO MOSTRAR/OCULTAR CONTRASEÑA
        private void BtnMostrarPassword_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;

            PasswordBox.UseSystemPasswordChar = !passwordVisible;
            btnMostrarPassword.Text = passwordVisible ? "🙈" : "👁";
        }

        // CENTRAR PANEL LOGIN
        private void CentrarPanelLogin()
        {
            int mitadPantalla = this.ClientSize.Width / 2;

            panelLogin.Left = mitadPantalla +
                (this.ClientSize.Width - mitadPantalla - panelLogin.Width) / 2;

            panelLogin.Top =
                (this.ClientSize.Height - panelLogin.Height) / 2;
        }

        // ===============================
        // PANEL AZUL IZQUIERDO
        // ===============================
        private void CrearRectanguloIzquierdo()
        {
            panelIzquierdo = new Panel();
            panelIzquierdo.BackColor = ColorTranslator.FromHtml("#192959");
            panelIzquierdo.Dock = DockStyle.Left;
            panelIzquierdo.Width = this.ClientSize.Width / 2;
            panelIzquierdo.SendToBack();
            this.Controls.Add(panelIzquierdo);

            CrearContenidoIzquierdo();

            this.Resize += (s, e) =>
            {
                panelIzquierdo.Width = this.ClientSize.Width / 2;
                CentrarContenidoIzquierdo();
            };
        }

        //Componentes del panel izquierdo
        private PictureBox logo;
        private Label lblBienvenidos;
        private Label lblServicio;
        private void CrearContenidoIzquierdo()
        {
            // LOGO
            logo = new PictureBox();
            logo.Image = CargarImagen("ManteHosApp.png");
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.Size = new Size(200, 200);
            logo.BackColor = Color.Transparent;

            // BIENVENIDOS
            lblBienvenidos = new Label();
            lblBienvenidos.Text = "¡BIENVENIDO A\nMANTEHOS!";
            lblBienvenidos.TextAlign = ContentAlignment.MiddleCenter;
            lblBienvenidos.AutoSize = false;
            lblBienvenidos.Size = new Size(400, 90);
            lblBienvenidos.ForeColor = Color.White;
            lblBienvenidos.Font = new Font("Tahoma", 30, FontStyle.Bold);
            lblBienvenidos.AutoSize = true;

            // SERVICIO
            lblServicio = new Label();
            lblServicio.Text = "Servicio de Mantenimiento";
            lblServicio.ForeColor = Color.Gainsboro;
            lblServicio.Font = new Font("Lucida Sans Unicode", 12, FontStyle.Regular);
            lblServicio.AutoSize = true;

            panelIzquierdo.Controls.Add(logo);
            panelIzquierdo.Controls.Add(lblBienvenidos);
            panelIzquierdo.Controls.Add(lblServicio);

            CentrarContenidoIzquierdo();
        }

        //Centrar contenido del panel izquierdo
        private void CentrarContenidoIzquierdo()
        {
            int centroX = panelIzquierdo.Width / 2;

            logo.Location = new Point(
                centroX - logo.Width / 2,
                panelIzquierdo.Height / 2 - 140
            );

            lblBienvenidos.Location = new Point(
                centroX - lblBienvenidos.Width / 2,
                logo.Bottom + 15
            );

            lblServicio.Location = new Point(
                centroX - lblServicio.Width / 2,
                lblBienvenidos.Bottom + 5
            );
        }

        // ===============================
        // UTILIDAD BORDES REDONDEADOS
        // ===============================
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }

        // ===============================
        // TEXTBOX REDONDEADO
        // ===============================
        private void RedondearTextBox(TextBox tb)
        {
            int gapWidth = 240;
            int gapHeight = 40;

            RoundedPanel panel = new RoundedPanel();
            panel.Size = new Size(gapWidth, gapHeight);
            panel.Radius = 12;

            tb.BorderStyle = BorderStyle.None;
            tb.BackColor = panel.BackColor;
            tb.Multiline = false;
            tb.ScrollBars = ScrollBars.None;
            tb.WordWrap = false;

            int textHeight = TextRenderer.MeasureText("Text", tb.Font).Height;
            tb.Height = textHeight + 2;
            tb.Width = panel.Width - 16;
            tb.Font = new Font("Calibri", 11, FontStyle.Regular);
            tb.Location = new Point(
                8,
                (panel.Height - tb.Height) / 2
            );

            this.Controls.Remove(tb);
            panel.Controls.Add(tb);
            this.Controls.Add(panel);
            panel.BringToFront();
        }

        // ===============================
        // CARGAR IMAGEN DESDE ARCHIVO
        // ===============================
        private Image CargarImagen(string nombreArchivo)
        {
            string path = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                nombreArchivo
            );

            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show(
                    $"No se encontró la imagen:\n{path}",
                    "Error de recursos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }

            return Image.FromFile(path);
        }

        // ===============================
        // BOTÓN REDONDEADO
        // ===============================
        private void RedondearBoton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = ColorTranslator.FromHtml("#192959");
            btn.ForeColor = Color.FromArgb(224, 224, 224);

            btn.Resize += (s, e) =>
            {
                btn.Region = new Region(
                    GetRoundedPath(btn.ClientRectangle, 12));
            };
        }


        // ===============================
        // EVENTOS Botón Login
        // ===============================
        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                s.login(UserBox.Text, PasswordBox.Text);

                var user = s.userLogued();

                MainDashboard dashboard = new MainDashboard(user, s);
                dashboard.Show();

                this.Hide();
            }
            catch (LoginException ex)
            {
                // Mensajes esperados (credenciales incorrectas, etc.)
                MessageBox.Show(
                    ex.Message,
                    "Error de inicio de sesión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (Exception ex)
            {
                // Errores inesperados
                MessageBox.Show(
                    "Ha ocurrido un error inesperado.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void ManteHosApp_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void UserBox_TextChanged(object sender, EventArgs e) { }
        private void PaswordBox_TextChanged(object sender, EventArgs e) { }

        private void btnDBIni_Click(object sender, EventArgs e)
        {
            s.DBInitialization();
        }
    }
}
