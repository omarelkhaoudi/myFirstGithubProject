using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_2018_V2
{
    public partial class Géstion_des_Regions : Form
    {
        List<Région> LesRégions = new List<Région>();
        public Géstion_des_Regions()
        {
            InitializeComponent();
        }

        private void Géstion_des_Regions_Load(object sender, EventArgs e)
        {
            Région région1 = new Région("Casablanca-Settat");
            région1.Ajouter(new Circonscription("Préfecture de Mohammédia", 322286));
            région1.Ajouter(new Circonscription("Préfecture de Casablanca", 2949805));
            région1.Ajouter(new Circonscription("Province de Nouaceur", 236119));
            région1.Ajouter(new Circonscription("Province de Médiouna", 122851));
            région1.Ajouter(new Circonscription("Marrakech", 928850));
            région1.CirconscriptionPrincipale = région1.Circonscriptions[0];
            LesRégions.Add(région1);

            Région région2 = new Région("Marrakech-Safi");
            LesRégions.Add(région2);

            Région région3 = new Région("Laâyoune-Sakia El Hamra");
            région3.CirconscriptionPrincipale =new Circonscription("Province de Laâyoune", 210023);
            région3.Ajouter(new Circonscription("Province de Boujdour", 46129));
            région3.Ajouter(new Circonscription("Province de Tarfaya", 10410));
            LesRégions.Add(région3);

                                                                       
            comboBox_Régions.DataSource = LesRégions;
            comboBox_Régions.DisplayMember = "Nom";
        }


        
        private void button_OrdreInitial_Click_1(object sender, EventArgs e)
        {
            {
                comboBox_Régions_SelectedIndexChanged(comboBox_Régions, new EventArgs());
            }

        }

        private void button_Trier_Click_1(object sender, EventArgs e)
        {
            Région Région = comboBox_Régions.SelectedItem as Région;

            if (Région.NombreCirconscriptions != 0)
            {
                string ordre = "croissant";
                List<Circonscription> Circonscriptions;

                if (radioButton_Décroissant.Checked) ordre = "décroissant";

                Circonscriptions = Région.TrierParPopulation(ordre);

                listBox_Circonscriptions.Items.Clear();

                foreach (Circonscription Circonscription in Circonscriptions)
                {
                    if (Région.CirconscriptionPrincipale != null &&
                        Circonscription.Nom == Région.CirconscriptionPrincipale.Nom)
                        listBox_Circonscriptions.Items.Add("--> " + Circonscription);
                    else
                        listBox_Circonscriptions.Items.Add(Circonscription);
                }
            }
        }

        private void comboBox_Régions_SelectedIndexChanged(object sender, EventArgs e)
        {
            Région Région = comboBox_Régions.SelectedItem as Région;

            listBox_Circonscriptions.Items.Clear();

            if (Région.NombreCirconscriptions != 0)
            {
                foreach (Circonscription Circonscription in Région.Circonscriptions)
                {                                                     
                    if (Région.CirconscriptionPrincipale != null &&
                        Circonscription.Nom == Région.CirconscriptionPrincipale.Nom)
                        listBox_Circonscriptions.Items.Add("--> " + Circonscription);
                    else
                        listBox_Circonscriptions.Items.Add(Circonscription);
                }
            }

            else
                listBox_Circonscriptions.Items.Add("Aucune circonscription !!!");

        }
        void Gestion_des_Régions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment fermer l'application ?",
                                "Attention",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }
    }

}










