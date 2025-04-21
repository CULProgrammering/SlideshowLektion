using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SlideshowLektion;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private int _slideIndex = 0;

    private readonly List<(string Title, string Content)> _slides = new()
        {
            ("Steg 1: Skapa en Linode-server", "Logga in på Linode.com\nVälj 'Create Linode' och välj Ubuntu som OS"),
            ("Steg 2: Anslut via SSH", "Öppna PowerShell:\nssh root@din-server-ip\nExempel: ssh root@111.222.333.444"),
            ("Steg 3: Uppdatera servern", "sudo apt update && sudo apt upgrade"),
            ("Steg 4: Installera Node.js", "curl -fsSL https://deb.nodesource.com/setup_18.x | sudo -E bash -\nsudo apt install -y nodejs"),
            ("Steg 5: Kopiera Node.js-serverfil", "På din dator:\nscp \"C:\\...\\WebSocketServer.js\" root@SERVER:/root/websocket-server/server.js"),
            ("Steg 6: Installera beroenden", "cd /root/websocket-server\nnpm init -y\nnpm install ws"),
            ("Steg 7: Testa att köra servern", "node server.js\nSka visa: WebSocket server running on ..."),
            ("Steg 8: Öppna port 8080", "sudo ufw allow 8080\nsudo ufw enable"),
            ("Steg 9: Använd PM2 för att köra i bakgrunden", "sudo npm install -g pm2\npm2 start server.js\npm2 save\npm2 startup\nFölj instruktionen som visas!"),
            ("Färdig!", "Nu kör din Node.js-server dygnet runt på Linode!"),
        };


    private readonly List<(string Title, string Content)> swehosting = new()
{
    ("Steg 1: Skapa en Swehosting-server", "Logga in på Swehosting.com\nVälj din server och konfigurera den med Ubuntu."),
    ("Steg 2: Anslut via Xterm.js", "Använd Swehostings inbyggda Xterm.js-konsol för att logga in.\nLogga in med root och ditt lösenord."),
    ("Steg 3: Uppdatera servern", "sudo apt update && sudo apt upgrade"),
    ("Steg 4: Installera Apache", "sudo apt install apache2"),
    ("Steg 5: Lägg till din webbplats", "Klona din hemsida till:\n/var/www/html/\nGå till din GitHub-repository och kopiera URL:n.\nAnvänd sedan följande kommando för att klona den:\ngit clone https://github.com/ditt-användarnamn/ditt-repository.git\nSkapa en konfigurationsfil:\nsudo nano /etc/apache2/sites-available/mywebsite.conf\nInnehåll:\n" +
    "<VirtualHost *:80>\n" +
    "    ServerAdmin webmaster@localhost\n" +
    "    DocumentRoot /var/www/html/Canvas\n" +
    "    ServerName DIN-IP\n" +
    "    ErrorLog ${APACHE_LOG_DIR}/error.log\n" +
    "    CustomLog ${APACHE_LOG_DIR}/access.log combined\n" +
    "</VirtualHost>"),
    ("Steg 6: Installera Microsoft SQL Server", "sudo apt install -y curl\ncurl https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -\nsudo curl https://packages.microsoft.com/config/ubuntu/22.04/prod.list > /etc/apt/sources.list.d/mssql-server.list\nsudo apt update\nsudo apt install mssql-server"),
    ("Steg 7: Installera Node.js", "curl -fsSL https://deb.nodesource.com/setup_18.x | sudo -E bash -\nsudo apt install -y nodejs"),
    ("Steg 8: Klona din Node.js-app från GitHub", "Gå till din GitHub-repository och kopiera URL:n.\nAnvänd sedan följande kommando för att klona den:\n" +
    "git clone https://github.com/ditt-användarnamn/ditt-repository.git"),
    ("Steg 9: Installera beroenden", "cd /path/to/your/app\nnpm install"),
    ("Steg 10: Starta din Node.js-app", "node app.js"),
    ("Steg 11: Använd PM2 för att köra i bakgrunden", "sudo npm install -g pm2\npm2 start app.js\npm2 save\npm2 startup\nFölj instruktionerna som visas!"),
    ("Steg 12: Konfigurera brandväggen (UFW)", "Öppna nödvändiga portar för HTTP (80), HTTPS (443) och SQL Server (1433):\n" +
    "sudo ufw allow 80\nsudo ufw allow 443\nsudo ufw allow 1433\nsudo ufw enable"),
    ("Steg 13: Starta om Apache", "sudo systemctl restart apache2"),
    ("Steg 14: Testa Apache", "Öppna en webbläsare och skriv serverns IP-adress (t.ex. http://DIN-IP) för att se om din webbplats fungerar."),
    ("Steg 15: Testa SQL Server", "Kontrollera att SQL Server körs korrekt:\n" +
    "sudo systemctl status mssql-server"),
    ("Steg 16: Kontrollera att Node.js-applikationen körs", "För att se att din Node.js-applikation körs, använd:\npm2 list"),
    ("Färdig!", "Din Node.js-applikation körs nu dygnet runt på din Swehosting-server!"),
};
    public MainWindow()
    {
        InitializeComponent();
        LoadSlide();
    }

    private void LoadSlide()
    {
        //if (_slideIndex >= _slides.Count)
        //{
        //    Application.Current.Shutdown();
        //    return;
        //}
        SlideTitle.Text = swehosting[_slideIndex].Title;
        SlideContent.Text = swehosting[_slideIndex].Content;
        //SlideTitle.Text = _slides[_slideIndex].Title;
        //SlideContent.Text = _slides[_slideIndex].Content;
    }

    private void NextSlide(object sender, RoutedEventArgs e)
    {
        _slideIndex++;
        LoadSlide();
    }

    private void PreviousSlide(object sender, RoutedEventArgs e)
    {
        _slideIndex--;
        LoadSlide();
    }
}