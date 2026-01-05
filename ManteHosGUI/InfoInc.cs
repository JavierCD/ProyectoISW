using ManteHos.Entities;
using ManteHos.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace ManteHosGUI
{
    public class InfoInc : Form
    {
        private ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.IContainer components;
        private TextBox textBox1;
        private ListBox AssignOp;
        private ListBox AllOp;
        private Button AñadirOperario;
        private Button RetirarOp;
        private Button button3;
        private IManteHosService service;
        private Incident inc;
        private WorkOrder workOrder;
        private Operator op;

        private Panel panelFormulario;
        private Label lblTitulo;
        private Label lblDescripcion;
        private Label lblAsignados;
        private Label lblDisponibles;
        private Button btnRegresar;



        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            if (service == null) return;

            this.inc = service.getCurrentIncident();
            this.workOrder = this.inc.WorkOrder;

            textBox1.Text = this.inc?.Description ?? "";

            AssignOp.DataSource = new BindingList<Operator>(this.workOrder.Operators.ToList());
            AssignOp.DisplayMember = "FullName";

            AllOp.DataSource = service.availableOperators(this.inc).ToList();
            AllOp.DisplayMember = "FullName";

            AssignOp.ClearSelected();
            AllOp.ClearSelected();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.AssignOp = new System.Windows.Forms.ListBox();
            this.AllOp = new System.Windows.Forms.ListBox();
            this.AñadirOperario = new System.Windows.Forms.Button();
            this.RetirarOp = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBox1
            // 
            this.textBox1.AccessibleName = "descripción";
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox1.Location = new System.Drawing.Point(46, 94);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(347, 81);
            this.textBox1.TabIndex = 1;
            this.textBox1.TabStop = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // AssignOp
            // 
            this.AssignOp.AccessibleName = "AsignOp";
            this.AssignOp.FormattingEnabled = true;
            this.AssignOp.ItemHeight = 16;
            this.AssignOp.Location = new System.Drawing.Point(46, 200);
            this.AssignOp.Name = "AssignOp";
            this.AssignOp.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.AssignOp.Size = new System.Drawing.Size(120, 84);
            this.AssignOp.TabIndex = 2;
            this.AssignOp.TabStop = false;
            this.AssignOp.SelectedIndexChanged += new System.EventHandler(this.AssignOp_SelectedIndexChanged);
            // 
            // AllOp
            // 
            this.AllOp.AccessibleName = "AllOp";
            this.AllOp.FormattingEnabled = true;
            this.AllOp.ItemHeight = 16;
            this.AllOp.Location = new System.Drawing.Point(273, 200);
            this.AllOp.Name = "AllOp";
            this.AllOp.Size = new System.Drawing.Size(120, 84);
            this.AllOp.TabIndex = 3;
            this.AllOp.SelectedIndexChanged += new System.EventHandler(this.AllOp_SelectedIndexChanged);
            // 
            // AñadirOperario
            // 
            this.AñadirOperario.Location = new System.Drawing.Point(172, 200);
            this.AñadirOperario.Name = "AñadirOperario";
            this.AñadirOperario.Size = new System.Drawing.Size(95, 23);
            this.AñadirOperario.TabIndex = 4;
            this.AñadirOperario.Text = "Añadir operario";
            this.AñadirOperario.UseVisualStyleBackColor = true;
            this.AñadirOperario.Click += new System.EventHandler(this.button1_Click);
            // 
            // RetirarOp
            // 
            this.RetirarOp.Location = new System.Drawing.Point(171, 261);
            this.RetirarOp.Name = "RetirarOp";
            this.RetirarOp.Size = new System.Drawing.Size(96, 23);
            this.RetirarOp.TabIndex = 5;
            this.RetirarOp.Text = "Retirar Operario";
            this.RetirarOp.UseVisualStyleBackColor = true;
            this.RetirarOp.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(247, 337);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Asignar orden de trabajo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // InfoInc
            // 
            this.ClientSize = new System.Drawing.Size(445, 411);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.RetirarOp);
            this.Controls.Add(this.AñadirOperario);
            this.Controls.Add(this.AllOp);
            this.Controls.Add(this.AssignOp);
            this.Controls.Add(this.textBox1);
            this.Name = "InfoInc";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public InfoInc(IManteHosService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            InitializeComponent();

            this.BackColor = ColorTranslator.FromHtml("#192959");
            this.WindowState = FormWindowState.Maximized;

            CrearPanelFormulario();

            this.Resize += (s, e) => CentrarPanel();
        }

        private void CrearPanelFormulario()
        {
            // ---------- PANEL ----------
            panelFormulario = new Panel
            {
                Size = new Size(900, 600),
                BackColor = Color.White
            };

            this.Controls.Add(panelFormulario);
            panelFormulario.BringToFront();

            // ---------- BOTÓN REGRESAR ----------
            btnRegresar = new Button
            {
                Size = new Size(60, 60),
                Location = new Point(15, 15),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            btnRegresar.FlatAppearance.BorderSize = 0;
            btnRegresar.BackgroundImage = CargarImagen("iconoRegresar.png");
            btnRegresar.BackgroundImageLayout = ImageLayout.Zoom;
            btnRegresar.Click += (s, e) => this.Close();

            this.Controls.Add(btnRegresar);
            btnRegresar.BringToFront();

            // ---------- TÍTULO ----------
            lblTitulo = new Label
            {
                Text = "INFORMACIÓN DE LA INCIDENCIA",
                Font = new Font("Lucida Sans Unicode", 24, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(180, 30)
            };

            panelFormulario.Controls.Add(lblTitulo);

            // ---------- DESCRIPCIÓN ----------
            lblDescripcion = new Label
            {
                Text = "Descripción de la incidencia:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(40, 100),
                AutoSize = true
            };

            panelFormulario.Controls.Add(lblDescripcion);

            textBox1.Location = new Point(40, 130);
            textBox1.Size = new Size(820, 80);
            textBox1.ReadOnly = true;

            panelFormulario.Controls.Add(textBox1);

            // ---------- OPERARIOS DISPONIBLES (IZQUIERDA) ----------
            lblDisponibles = new Label
            {
                Text = "Operarios disponibles",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(40, 240),
                AutoSize = true
            };

            panelFormulario.Controls.Add(lblDisponibles);

            AllOp.Location = new Point(40, 270);
            AllOp.Size = new Size(300, 180);

            panelFormulario.Controls.Add(AllOp);

            // ---------- OPERARIOS ASIGNADOS (DERECHA) ----------
            lblAsignados = new Label
            {
                Text = "Operarios asignados",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(560, 240),
                AutoSize = true
            };

            panelFormulario.Controls.Add(lblAsignados);

            AssignOp.Location = new Point(560, 270);
            AssignOp.Size = new Size(300, 180);
            AssignOp.SelectionMode = SelectionMode.None;

            panelFormulario.Controls.Add(AssignOp);

            // ---------- BOTONES AÑADIR / RETIRAR ----------

            // Botón AÑADIR
            AñadirOperario.Text = "";
            AñadirOperario.Size = new Size(55, 55);
            AñadirOperario.Location = new Point(420, 290);
            AñadirOperario.FlatStyle = FlatStyle.Flat;
            AñadirOperario.FlatAppearance.BorderSize = 0;
            AñadirOperario.BackColor = Color.Transparent;
            AñadirOperario.Cursor = Cursors.Hand;
            AñadirOperario.BackgroundImage = CargarImagen("iconoAsignar.png");
            AñadirOperario.BackgroundImageLayout = ImageLayout.Zoom;

            panelFormulario.Controls.Add(AñadirOperario);

            // Botón RETIRAR
            RetirarOp.Text = "";
            RetirarOp.Size = new Size(55, 55);
            RetirarOp.Location = new Point(420, 360);
            RetirarOp.FlatStyle = FlatStyle.Flat;
            RetirarOp.FlatAppearance.BorderSize = 0;
            RetirarOp.BackColor = Color.Transparent;
            RetirarOp.Cursor = Cursors.Hand;
            RetirarOp.BackgroundImage = CargarImagen("iconoRetirar.png");
            RetirarOp.BackgroundImageLayout = ImageLayout.Zoom;

            panelFormulario.Controls.Add(RetirarOp);


            // ---------- BOTÓN FINAL (IMAGEN) ----------
            button3.Size = new Size(200, 55);
            button3.Location = new Point(
                panelFormulario.Width / 2 - button3.Width / 2,
                500
            );

            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.BackColor = Color.Transparent;
            button3.Cursor = Cursors.Hand;
            button3.Text = "";
            button3.BackgroundImage = CargarImagen("iconoCerrarOrden.png");
            button3.BackgroundImageLayout = ImageLayout.Zoom;

            panelFormulario.Controls.Add(button3);


            CentrarPanel();
        }

        private void CentrarPanel()
        {
            panelFormulario.Left =
                (this.ClientSize.Width - panelFormulario.Width) / 2;
            panelFormulario.Top =
                (this.ClientSize.Height - panelFormulario.Height) / 2 - 20;
        }

        private Image CargarImagen(string nombreArchivo)
        {
            string path = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                nombreArchivo);

            return System.IO.File.Exists(path)
                ? Image.FromFile(path)
                : null;
        }


        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void BaseForm_Load(object sender, System.EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AllOp.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un operario");
                return;
            }

            try
            {
                Incident inc = service.getCurrentIncident();
                WorkOrder workOrder = inc.WorkOrder;

                Operator op = (Operator)AllOp.SelectedItem;

                var ops = (BindingList<Operator>)AssignOp.DataSource;

                if (ops.Any(x => x.FullName == op.FullName))
                {
                    MessageBox.Show("Operario ya asignado");
                    return;
                }

                service.addOperator(workOrder, op);
                ops.Add(op);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

 

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AllOp.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione un operario");
                return;
            }

            try
            {
                Incident inc = service.getCurrentIncident();
                WorkOrder workOrder = inc.WorkOrder;

                Operator op = (Operator)AllOp.SelectedItems[0];

                var ops = (BindingList<Operator>)AssignOp.DataSource;

                var toRemove = ops.FirstOrDefault(x => x.Id == op.Id);
                if (toRemove == null)
                {
                    MessageBox.Show("Operario no asignado");
                    return;
                }

                ops.Remove(toRemove);
                service.quitarOperator(op, workOrder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                service.Commit();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            service.Commit();
            this.Close();
        }

        private void AssignOp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AllOp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            service.Commit();
            base.OnFormClosing(e);
        }
    }
}

