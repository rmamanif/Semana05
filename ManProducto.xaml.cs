using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Entity;
using Business;

namespace Semana05
{
    /// <summary>
    /// Lógica de interacción para ManProducto.xaml
    /// </summary>
    public partial class ManProducto : Window
    {
        public int ID { get; set; }
        public ManProducto(int Id)
        {
            InitializeComponent();
            ID = Id;
            if (ID > 0)
            {
                BProducto bProducto = new BProducto();
                List<Producto> categorias = new List<Producto>();
                categorias = bProducto.Listar(ID);
                if (categorias.Count > 0)
                {
                    txtId.Text = categorias[0].IdProducto.ToString();
                    txtNombre.Text = categorias[0].NombreProducto;
                    txtProveedor.Text = categorias[0].IdProveedor.ToString();
                    txtCategoria.Text = categorias[0].IdCategoria.ToString();
                    txtCantidadUnidad.Text = categorias[0].CantidadPorUnidad;
                    txtPrecioUnidad.Text = categorias[0].PrecioUnidad.ToString();
                    txtUnidadesExist.Text = categorias[0].UnidadesEnExistencia.ToString();
                    txtUnidadesPedido.Text = categorias[0].UnidadesEnPedido.ToString();
                    txtNivelPedido.Text = categorias[0].NivelNuevoPedido.ToString();
                    txtSuspendido.Text = categorias[0].Suspendido.ToString();
                    txtCategoriaProducto.Text = categorias[0].CategoriaProducto;
                }
            }
        }

        private void BtnGrabar_Click(object sender, RoutedEventArgs e)
        {
            BProducto bProducto = null;
            bool result = true;
            try
            {
                bProducto = new BProducto();

                Producto pnew = new Producto
                {
                    IdProducto = ID > 0 ? ID : 0 ,
                    NombreProducto = txtNombre.Text,
                    IdCategoria =  Int32.Parse(txtCategoria.Text) ,
                    IdProveedor = Int32.Parse(txtProveedor.Text),
                    CantidadPorUnidad = txtCantidadUnidad.Text,
                    PrecioUnidad = Int32.Parse(txtPrecioUnidad.Text),
                    UnidadesEnExistencia = Int32.Parse(txtUnidadesExist.Text),
                    UnidadesEnPedido = Int32.Parse(txtUnidadesPedido.Text),
                    NivelNuevoPedido = Int32.Parse(txtNivelPedido.Text),
                    Suspendido = Int32.Parse(txtSuspendido.Text),
                    CategoriaProducto = txtCategoria.Text,
                };


                if (ID > 0)
                {
                    result = bProducto.Actualizar(pnew);
                }
                else
                {  
                    result = bProducto.Insertar(pnew);

                }
                
                if (!result)
                {
                    MessageBox.Show("resultado inexistente");
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                bProducto = null;
            }

        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            BProducto bProducto = null;
            bool result = true;
            try
            {
                bProducto = new BProducto();
                if (ID > 0)
                {
                    result = bProducto.Eliminar(ID);
                }
                if (result)
                {
                    Close();
                }
                else
                {
                    MessageBox.Show(" error para eliminar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }
    }
}
