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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirAtlantique.Pages
{
    /// <summary>
    /// Logique d'interaction pour AjouterEmployé.xaml
    /// </summary>
    public partial class AjouterEmployé : UserControl
    {
        public AjouterEmployé()
        {
            InitializeComponent();
            List<Model.Metier> listeMetier = LiaisonBDD.ListeMetiers();
            foreach (var metier in listeMetier)
            {
                lesMetiers.Items.Add(metier.nom);
            }
        }

        private void ajouterEmploye_Click(object sender, RoutedEventArgs e)
        {
            //identifiant par défaut de l'employé (prénom.nom)
            var login = prenomEmploye.Text.ToLower() + "." + nomEmploye.Text.ToLower();
            //mot de passe par défaut de l'employé (prénom.nom) A définir par l'utilisateur ensuite?
            var mdp = prenomEmploye.Text.ToLower() + "." + nomEmploye.Text.ToLower();
            //mail par défaut de l'employé (prénom.nom@airatlantique.com)
            var mail = prenomEmploye.Text.ToLower() + "." + nomEmploye.Text.ToLower() + "@airatlantique.com";

            List<Model.Metier> listeMetier = LiaisonBDD.ListeMetiers();
            List<string> metierChoisis = lesMetiers.SelectedItems.Cast<string>().ToList();
            List<Model.Metier> LesMetiers = new List<Model.Metier>();

            foreach (var metier in listeMetier)
            {
                foreach (var item in metierChoisis)
                {
                    if (metier.nom == item)
                        LesMetiers.Add(metier);
                }
            }
            ICollection<Model.Metier> collectionMetiers = LesMetiers;

            LiaisonBDD.AddEmploye(nomEmploye.Text, prenomEmploye.Text, mdp, login, mail, collectionMetiers);
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
