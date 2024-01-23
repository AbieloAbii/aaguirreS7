using System.Net;

namespace serviciosWeb.Vistas;

public partial class AgregarEstudiante : ContentPage
{
	public AgregarEstudiante()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
			cliente.UploadValues("http://172.22.64.1/moviles/post.php", "POST", parametros);
			Navigation.PushAsync(new inicio());

        }
		catch (Exception ex)
		{

			DisplayAlert("Error", ex.Message, "CERRAR");
		}
    }
}