using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace ProbandoActualizaciones
{
	public partial class Form1 : Form
	{

		string currentVersion = "1.0";
		string versionUrl = "https://raw.githubusercontent.com/AleCaceres1/ProbandoActualizaciones/refs/heads/main/version.json";

		public Form1()
		{
			InitializeComponent();
			lb_current.Text = "Versión: " + currentVersion;
		}
		public void CheckForUpdates(string url, string currentVersion)
		{
			using (var cliente = new WebClient())
			{
				try
				{
					// Descargar archivo de versión desde GitHub
					var versionData = cliente.DownloadString(versionUrl);
					JObject versionJson = JObject.Parse(versionData);

					string nuevaVersion = versionJson["version"].ToString();
					string downloadUrl = versionJson["url"].ToString();

					if (nuevaVersion != currentVersion)
					{
						MessageBox.Show("Nueva versión"+ nuevaVersion +"disponible. Iniciando actualización...");

						// Descargar nueva versión
						//string tempFilePath = Path.Combine(Path.GetTempPath(), "miapp_v" + nuevaVersion + ".zip");
						//cliente.DownloadFile(downloadUrl, tempFilePath);

						// Aquí puedes extraer el archivo y reemplazar los archivos de tu aplicación actual

						// También puedes lanzar un actualizador independiente que realice el reemplazo.
						//MessageBox.Show("Actualización descargada. Procede a instalar.");
					}
					else
					{
						MessageBox.Show("Ya tienes la última versión.");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error al verificar la actualización: " + ex.Message);
				}
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			CheckForUpdates(versionUrl, currentVersion);
		}
	}
	}


