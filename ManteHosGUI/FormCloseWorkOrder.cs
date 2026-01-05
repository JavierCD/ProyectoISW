using ManteHos.Entities;
using ManteHos.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ManteHosGUI
{
    public partial class FormCloseWorkOrder : BaseForm
    {
        private readonly IManteHosService service;
        private WorkOrder selectedWorkOrder;

        private Panel panelFormulario;
        private Label lblTitulo;
        private Button btnRegresar;

        private List<WorkOrder> workOrders;
        private DataGridView dgvParts;


        public FormCloseWorkOrder(IManteHosService service)
        {
            InitializeComponent();
            this.service = service;

            this.BackColor = ColorTranslator.FromHtml("#192959");

            CrearPanelFormulario();
            ConfigurarBotonCerrar();

            this.Resize += (s, e) => CentrarPanel();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadWorkOrders();
        }

        private void LoadWorkOrders()
        {
            workOrders = service.getOrdersFromOperator().ToList();

            dgvWorkOrders.DataSource = workOrders
                .Select(o => new
                {
                    NumeroOrden = o.Id,
                    Incidente = o.Incident.Description,
                    EstadoIncidente = o.Incident.Status.ToString(),
                    FechaInicio = o.StartDate,
                    FechaFin = o.EndDate
                })
                .ToList();

            dgvWorkOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWorkOrders.RowHeadersVisible = false;
            dgvWorkOrders.ReadOnly = true;
            dgvWorkOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        private void dgvWorkOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvWorkOrders.Columns[e.ColumnIndex].Name != "EstadoIncidente")
                return;

            string estado = e.Value?.ToString();

            if (estado == "pendiente")
                dgvWorkOrders.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            else if (estado == "en curso")
                dgvWorkOrders.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            else if (estado == "terminada")
                dgvWorkOrders.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            else if (estado == "rechazada")
                dgvWorkOrders.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
        }

        private void dgvWorkOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvWorkOrders.CurrentRow == null) return;

            int idOrden = (int)dgvWorkOrders.CurrentRow.Cells["NumeroOrden"].Value;

            selectedWorkOrder =
                workOrders.FirstOrDefault(o => o.Id == idOrden);

            if (selectedWorkOrder == null) return;

            // -------- INCIDENTE ----------
            txtIncident.Text = selectedWorkOrder.Incident.Description;

            // -------- COSTE TOTAL ----------
            txtPartsCost.Text =
                selectedWorkOrder.TotalPartsCost().ToString("0.00") + " €";

            // -------- PIEZAS UTILIZADAS ----------
            dgvParts.DataSource = selectedWorkOrder.UsedParts
                .Select(up => new
                {
                    Codigo = up.Part.Code,
                    Descripcion = up.Part.Description,
                    Cantidad = up.Quantity,
                    PrecioUnitario = up.Part.UnitPrice,
                    Total = up.Quantity * up.Part.UnitPrice
                })
                .ToList();

            dtpCloseDate.Value = DateTime.Now;
        }



        private void btnCloseOrder_Click(object sender, EventArgs e)
        {
            if (selectedWorkOrder == null) return;

            if (string.IsNullOrWhiteSpace(txtReport.Text))
            {
                MessageBox.Show("Debe indicar el trabajo realizado");
                return;
            }

            if (selectedWorkOrder.HasPendingParts())
            {
                MessageBox.Show(
                    "No se puede cerrar la orden porque quedan piezas pendientes",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            try
            {
                service.AssignEndDateForWorkOrder(selectedWorkOrder, dtpCloseDate.Value);
                service.stablishRepairReportForWorkOrder(selectedWorkOrder,txtReport.Text);
                service.Commit();

                MessageBox.Show("Orden cerrada correctamente");
                LoadWorkOrders();
                ClearForm();
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

        private void ClearForm()
        {
            txtIncident.Clear();
            txtPartsCost.Clear();
            txtReport.Clear();
            selectedWorkOrder = null;
        }

        // ================= UI =================
        private void CrearPanelFormulario()
        {
            // ---------- PANEL ----------
            panelFormulario = new Panel
            {
                Size = new Size(1000, 750),
                BackColor = Color.White,
                AutoScroll = true
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
                Text = "CERRAR ORDEN DE TRABAJO",
                Font = new Font("Lucida Sans Unicode", 26, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.Black,
                Location = new Point(230, 40)
            };

            panelFormulario.Controls.Add(lblTitulo);

            // ---------- CONTROLES DEL DESIGNER ----------
            panelFormulario.Controls.Add(dgvWorkOrders);
            panelFormulario.Controls.Add(lblIncident);
            panelFormulario.Controls.Add(txtIncident);
            panelFormulario.Controls.Add(lblCost);
            panelFormulario.Controls.Add(txtPartsCost);
            panelFormulario.Controls.Add(lblDate);
            panelFormulario.Controls.Add(dtpCloseDate);
            panelFormulario.Controls.Add(lblReport);
            panelFormulario.Controls.Add(txtReport);
            panelFormulario.Controls.Add(btnCloseOrder);

            // ---------- TABLA ÓRDENES ----------
            dgvWorkOrders.Location = new Point(40, 120);
            dgvWorkOrders.Size = new Size(900, 150);
            dgvWorkOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWorkOrders.ReadOnly = true;
            dgvWorkOrders.RowHeadersVisible = false;
            dgvWorkOrders.CellFormatting += dgvWorkOrders_CellFormatting;

            // ---------- TABLA PIEZAS ----------
            dgvParts = new DataGridView
            {
                Size = new Size(900, 120),
                Location = new Point(40, 290),
                ReadOnly = true,
                RowHeadersVisible = false,
                AutoGenerateColumns = false, 
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            //CREAR COLUMNAS A MANO
            dgvParts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Codigo",
                HeaderText = "Código",
                DataPropertyName = "Codigo"
            });

            dgvParts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Descripcion",
                HeaderText = "Descripción",
                DataPropertyName = "Descripcion"
            });

            dgvParts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cantidad",
                HeaderText = "Cantidad",
                DataPropertyName = "Cantidad"
            });

            dgvParts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PrecioUnitario",
                HeaderText = "Precio Unitario (€)",
                DataPropertyName = "PrecioUnitario"
            });

            dgvParts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Total",
                HeaderText = "Total (€)",
                DataPropertyName = "Total"
            });

            dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //ESTILO CABECERAS
            dgvParts.EnableHeadersVisualStyles = false;
            dgvParts.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvParts.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvParts.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9, FontStyle.Bold);

            panelFormulario.Controls.Add(dgvParts);


            // ---------- INCIDENTE ----------
            lblIncident.Location = new Point(40, 440);
            txtIncident.Location = new Point(180, 440);
            txtIncident.Width = 760;

            // ---------- COSTE ----------
            lblCost.Location = new Point(40, 480);
            txtPartsCost.Location = new Point(180, 480);

            // ---------- FECHA ----------
            lblDate.Location = new Point(520, 480);
            dtpCloseDate.Location = new Point(650, 478);

            // ---------- INFORME ----------
            lblReport.Location = new Point(40, 520);
            txtReport.Location = new Point(40, 550);
            txtReport.Size = new Size(900, 80);

            // ---------- BOTÓN CERRAR ----------
            btnCloseOrder.Location = new Point(
                (panelFormulario.Width / 2 - btnCloseOrder.Width / 2) - 10,
                650
            );
        }


        private void CentrarPanel()
        {
            panelFormulario.Left =
                (this.ClientSize.Width - panelFormulario.Width) / 2;
            panelFormulario.Top =
                (this.ClientSize.Height - panelFormulario.Height) / 2 - 30;
        }

        private void ConfigurarBotonCerrar()
        {
            btnCloseOrder.Text = "";
            btnCloseOrder.Size = new Size(120, 60);
            btnCloseOrder.FlatStyle = FlatStyle.Flat;
            btnCloseOrder.FlatAppearance.BorderSize = 0;
            btnCloseOrder.BackColor = Color.Transparent;
            btnCloseOrder.Cursor = Cursors.Hand;

            btnCloseOrder.BackgroundImage =
                CargarImagen("iconoCerrarOrden.png");
            btnCloseOrder.BackgroundImageLayout = ImageLayout.Zoom;
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

        private void FormCloseWorkOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
