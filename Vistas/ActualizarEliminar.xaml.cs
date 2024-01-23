using serviciosWeb.Modelos;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace serviciosWeb.Vistas
{
    public partial class ActualizarEliminar : ContentPage
    {
        private readonly Estudiante estudiante;

        public ActualizarEliminar(Estudiante datos)
        {
            InitializeComponent();
            txtCodigo.Text = datos.codigo.ToString();
            txtNombre.Text = datos.nombre;
            txtApellido.Text = datos.apellido;
            txtEdad.Text = datos.edad.ToString();
            estudiante = datos;
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores actuales de los campos de entrada
                string codigo = txtCodigo.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string edad = txtEdad.Text;

                // Construir la URL para la solicitud PUT
                string url = $"http://172.22.64.1/moviles/post.php?codigo={codigo}&nombre={nombre}&apellido={apellido}&edad={edad}";

                // Iniciar un cliente HTTP para realizar la solicitud PUT
                using (HttpClient cliente = new HttpClient())
                {
                    // Enviar una solicitud PUT de forma asincrónica
                    HttpResponseMessage response = await cliente.PutAsync(url, null);

                    // Asegurarse de que la solicitud fue exitosa
                    response.EnsureSuccessStatusCode();

                    // Mensajes de consola para depuración
                    Console.WriteLine($"Status Code: {response.StatusCode}");
                    Console.WriteLine($"Response Content: {await response.Content.ReadAsStringAsync()}");
                }

                // Navegar de vuelta a la página de inicio después de la actualización exitosa
                await Navigation.PushAsync(new Vistas.inicio());
            }
            catch (Exception ex)
            {
                // Mostrar una alerta en caso de error
                DisplayAlert("ERROR", ex.Message, "CERRAR");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Obtener el código actual del campo de entrada
                string codigo = txtCodigo.Text;

                // Construir la URL para la solicitud DELETE
                string url = $"http://172.22.64.1/moviles/post.php?codigo={codigo}";

                // Iniciar un cliente web para realizar la solicitud DELETE
                WebClient cliente = new WebClient();

                // Enviar una solicitud DELETE
                var parametros = new System.Collections.Specialized.NameValueCollection();
                cliente.UploadValues(url, "DELETE", parametros);

                // Navegar de vuelta a la página de inicio después de la eliminación exitosa
                Navigation.PushAsync(new inicio());
            }
            catch (Exception ex)
            {
                // Mostrar una alerta en caso de error
                DisplayAlert("ERROR", ex.Message, "CERRAR");
            }
        }
    }
}
