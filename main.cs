using System;
using System.Windows.Forms;

public class AlgasKalkulators : Form
{
    private Label stundasLikmeTxt, nedelasStundasTxt, menesaAlgaTxt, gadaAlgaTxt;
    private TextBox stundasLikmeBox, nedelasStundasBox, menesaAlgaBox, gadaAlgaBox;
    private Button aprekinatPoga, notiritPoga;

    public AlgasKalkulators()
    {
        this.Text = "Algas kalkulators";
        this.Size = new System.Drawing.Size(400, 300);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;

        // Nosaukumi
        stundasLikmeTxt = new Label() { Text = "Stundas likme (€):", Location = new System.Drawing.Point(20, 20), AutoSize = true };
        nedelasStundasTxt = new Label() { Text = "Stundas nedēļā:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
        menesaAlgaTxt = new Label() { Text = "Mēneša alga (€):", Location = new System.Drawing.Point(20, 140), AutoSize = true };
        gadaAlgaTxt = new Label() { Text = "Gada alga (€):", Location = new System.Drawing.Point(20, 180), AutoSize = true };

        // Teksta ievades lauki
        stundasLikmeBox = new TextBox() { Location = new System.Drawing.Point(150, 20), Width = 200 };
        nedelasStundasBox = new TextBox() { Location = new System.Drawing.Point(150, 60), Width = 200 };
        menesaAlgaBox = new TextBox() { Location = new System.Drawing.Point(150, 140), Width = 200, ReadOnly = true };
        gadaAlgaBox = new TextBox() { Location = new System.Drawing.Point(150, 180), Width = 200, ReadOnly = true };

        // Aprēķināšanas/Notīrīšanas pogas
        aprekinatPoga = new Button() { Text = "Aprēķināt", Location = new System.Drawing.Point(150, 100), Width = 90 };
        aprekinatPoga.Click += AprekinatPoga_Click;

        notiritPoga = new Button() { Text = "Notīrīt", Location = new System.Drawing.Point(260, 100), Width = 90 };
        notiritPoga.Click += NotiritPoga_Click;

        // Darbību pievienošana
        this.Controls.Add(stundasLikmeTxt);
        this.Controls.Add(nedelasStundasTxt);
        this.Controls.Add(menesaAlgaTxt);
        this.Controls.Add(gadaAlgaTxt);
        this.Controls.Add(stundasLikmeBox);
        this.Controls.Add(nedelasStundasBox);
        this.Controls.Add(menesaAlgaBox);
        this.Controls.Add(gadaAlgaBox);
        this.Controls.Add(aprekinatPoga);
        this.Controls.Add(notiritPoga);
    }

    private void AprekinatPoga_Click(object sender, EventArgs e)
    {
        try
        {
            double likme = double.Parse(stundasLikmeBox.Text);
            double h = double.Parse(nedelasStundasBox.Text);

            double menesaAlga = likme * h * 4;
            double gadaAlga = menesaAlga * 12;

            menesaAlgaBox.Text = menesaAlga.ToString("F2");
            gadaAlgaBox.Text = gadaAlga.ToString("F2");
        }
        catch (FormatException)
        {
            MessageBox.Show("Lūdzu ievadiet derīgus skaitļus!", "Kļūda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void NotiritPoga_Click(object sender, EventArgs e)
    {
        stundasLikmeBox.Text = "";
        nedelasStundasBox.Text = "";
        menesaAlgaBox.Text = "";
        gadaAlgaBox.Text = "";
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new AlgasKalkulators());
    }
}
