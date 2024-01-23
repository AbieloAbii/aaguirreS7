using Newtonsoft.Json;
using serviciosWeb.Modelos;
using System.Collections.ObjectModel;

namespace serviciosWeb.Vistas;

public partial class inicio : ContentPage
{
	private const string Url = "http://172.22.64.1/moviles/post.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> estud;

    public inicio()
	{
		InitializeComponent();
		Obtener();
	}

	public async void Obtener()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		estud = new ObservableCollection<Estudiante>(mostrarEst);
		listaEstudiantes.ItemsSource = estud;
	}

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new AgregarEstudiante());
    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var objEstudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new ActualizarEliminar(objEstudiante));
    }
}