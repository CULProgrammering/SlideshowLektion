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

        SlideTitle.Text = _slides[_slideIndex].Title;
        SlideContent.Text = _slides[_slideIndex].Content;
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