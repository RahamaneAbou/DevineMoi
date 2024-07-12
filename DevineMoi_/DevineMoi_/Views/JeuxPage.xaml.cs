using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DevineMoi_.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class JeuxPage : ContentPage
	{
		private int nombreGenere;
		private int nombreTentatives;
		private int reponseCorrecte; // Variable pour stocker la réponse correcte

		public JeuxPage()
		{
			InitializeComponent();
		}

		private void Btn_Clicked(Object sender, EventArgs e)
		{
			ListContainer.IsVisible = !ListContainer.IsVisible;
		}

		private void Back_(int a)
		{
			Niv1(a);
		}

		private void Niv_1(object sender, EventArgs e)
		{
			Back_(1);
		}

		private void Niv_2(object sender, EventArgs e)
		{
			Back_(2);
		}

		private void Niv_3(object sender, EventArgs e)
		{
			Back_(3);
		}

		private void Niv1(int y)
		{
			if (ListContainer.IsVisible)
			{
				int[] Tab = Choix_niv(y);
				Random ran = new Random();
				nombreGenere = ran.Next(Tab[0], Tab[1]);
				nombreTentatives = Tab[2];
				reponseCorrecte = nombreGenere; // Mettre à jour la réponse correcte

				limite1.Text = Tab[0].ToString();
				limite2.Text = Tab[1].ToString();
				Chance.Text = nombreTentatives.ToString();
			}
		}

		private int[] Choix_niv(int a)
		{
			int lim_1 = 1, lim_2 = 10, chance = 3;
			lim_2 *= a;
			chance += a;


			return new int[] { lim_1, lim_2, chance };
		}

		private void OnSubmit(object sender, EventArgs e)
		{
			if (int.TryParse(Choix_nbr.Text, out int choix))
			{
				if (choix == reponseCorrecte)
				{
					// Afficher message de félicitations en couleur green
					FinDePartie("Félicitations! Vous avez deviné le bon nombre.", Color.Green);
					Choix_nbr.IsVisible = false;
					(sender as Button).IsVisible = false;
				}
				else
				{
					nombreTentatives--;
					Chance.Text = nombreTentatives.ToString();

					if (nombreTentatives <= 0)
					{
						// Afficher message d'échec en couleur chocolate
						FinDePartie($"Désolé! Vous avez épuisé toutes vos chances. Le bon nombre était {reponseCorrecte}.", Color.Chocolate);
					}
					else
					{
						if (choix < reponseCorrecte)
						{
							MessageLabel.Text = "Essayez encore! Le nombre est plus grand.";
						}
						else
						{
							MessageLabel.Text = "Essayez encore! Le nombre est plus petit.";
						}
						MessageLabel.TextColor = Color.Red;
					}
				}
			}
			else
			{
				MessageLabel.Text = "Veuillez entrer un nombre valide.";
				MessageLabel.TextColor = Color.Red;
			}
		}

		private void FinDePartie(string message, Color textColor)
		{
			// Effacer tout le contenu actuel
			Content = null;

			// Afficher le message de fin avec la couleur spécifiée
			Label messageLabel = new Label
			{
				Text = message,
				TextColor = textColor,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			// Bouton pour recommencer
			Button recommencerButton = new Button
			{
				Text = "Rejouer",
				BackgroundColor = Color.Green,
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};
			recommencerButton.Clicked += (s, e) => Navigation.PushAsync(new JeuxPage());

			// Placer le message et le bouton dans un StackLayout vertical
			StackLayout stackLayout = new StackLayout
			{
				Children = { messageLabel, recommencerButton },
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};

			// Définir le nouveau contenu de la page
			Content = stackLayout;
		}
	}
}
