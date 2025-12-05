using Examen.Suport.Classes;
using Examen.Suport.Formularis;
using Examen.Suport.Funcions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen.Suport.Tcp
{
    //public static class ClientTcp_
    //{
    //    private static DateTime _marcaDeTemps = DateTime.Now;

    //    public static string EnviarEstat(AdreçaPort adreçaPort, EstacioAlumne estacioAlumne, List<AplicacioEnUs> aplicacionsEnUs, TipusMissatge estat, Action pitar, Action bloquejar, Action aturar, Action fiServidor, string text = null, bool sync = false)
    //    {
    //        try
    //        {
    //            var ret = sync ?
    //                EnviarEstatSync(adreçaPort, estacioAlumne, aplicacionsEnUs, estat, pitar, bloquejar, aturar, fiServidor, text) :
    //                Task.Run(async () => await EnviarEstatAsync(adreçaPort, estacioAlumne, aplicacionsEnUs, estat, pitar, bloquejar, aturar, fiServidor, text)).GetAwaiter().GetResult();

    //            return ret;
    //        }
    //        catch (TimeoutException exTimeout)
    //        {
    //            if (estat != TipusMissatge.FiServidor)
    //                MostraError(exTimeout, estat);
    //        }
    //        catch (SocketException exSocket)
    //        {
    //            if (estat != TipusMissatge.FiServidor)
    //                MostraError(exSocket, estat);
    //        }
    //        catch (InvalidOperationException exInvalidOperation)
    //        {
    //            if (estat != TipusMissatge.FiServidor)
    //                MostraError(exInvalidOperation, estat);
    //        }
    //        catch (IOException exIo)
    //        {
    //            if (estat != TipusMissatge.FiServidor)
    //                MostraError(exIo, estat);
    //        }
    //        catch (Exception ex)
    //        {
    //            ex.Mostrar();
    //        }

    //        return null;
    //    }

    //    private static string EnviarEstatSync(AdreçaPort adreçaPort, EstacioAlumne estacioAlumne,
    //        List<AplicacioEnUs> aplicacionsEnUs, TipusMissatge estat, Action pitar, Action bloquejar, Action aturar,
    //        Action fiServidor, string text)
    //    {
    //        using var client = new TcpClient();
    //        client.NoDelay = true; // Disable Nagle's algorithm for low latency
    //        client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
    //        client.SendTimeout = Properties.Settings.Default.TimeOut * 1000;
    //        client.ReceiveTimeout = Properties.Settings.Default.TimeOut * 1000;
    //        client.Connect(adreçaPort.Adreça, adreçaPort.Port);

    //        var stream = client.GetStream();

    //        estacioAlumne ??= new EstacioAlumne("", Guid.Empty);

    //        var estatText =
    //            $"{estat}:{estacioAlumne.Serialitzar().ToBase64()}:{text}:{aplicacionsEnUs.Serialitzar().ToBase64()}"
    //                .CompressToBase64();
    //        var missatge = Encoding.UTF8.GetBytes(estatText);
    //        stream.Write(missatge, 0, missatge.Length);

    //        var resposta = new byte[Helper.BufferSize];
    //        var bytesLlegits = stream.Read(resposta, 0, resposta.Length);
    //        var respostaText = Encoding.UTF8.GetString(resposta, 0, bytesLlegits);
    //        respostaText = respostaText.DecompressFromBase64();

    //        //Trace.WriteLine($"Resposta del servidor: {respostaText}");

    //        var rt = respostaText.Split('^');
    //        if (rt.Length > 1)
    //        {
    //            if (bool.Parse(rt[1]))
    //                pitar.Invoke();
    //            if (bool.Parse(rt[2]))
    //                bloquejar.Invoke();
    //            if (bool.Parse(rt[3]))
    //                aturar.Invoke();
    //            if (bool.Parse(rt[4]))
    //                fiServidor.Invoke();
    //        }

    //        return rt.First();
    //    }

    //    private static async Task<string> EnviarEstatAsync(AdreçaPort adreçaPort, EstacioAlumne estacioAlumne,
    //        List<AplicacioEnUs> aplicacionsEnUs, TipusMissatge estat, Action pitar, Action bloquejar, Action aturar,
    //        Action fiServidor, string text = null)
    //    {
    //        var connectionTimeout = Properties.Settings.Default.TimeOut * 1000;

    //        using var client = new TcpClient();
    //        var connectionTask = client.ConnectAsync(adreçaPort.Adreça, adreçaPort.Port);
    //        var timeoutTask = Task.Delay(connectionTimeout);
    //        var completedTask = await Task.WhenAny(connectionTask, timeoutTask);

    //        if (completedTask == timeoutTask)
    //            throw new TimeoutException("Temps d'espera de connexió superat.");

    //        await connectionTask;

    //        client.NoDelay = true;
    //        client.SendTimeout = Properties.Settings.Default.TimeOut * 1000;
    //        client.ReceiveTimeout = Properties.Settings.Default.TimeOut * 1000;

    //        var stream = client.GetStream();

    //        estacioAlumne ??= new EstacioAlumne("", Guid.Empty);

    //        var json = aplicacionsEnUs.Serialitzar();
    //        var estatText = $"{estat}:{estacioAlumne.Serialitzar().ToBase64()}:{text}:{json.ToBase64()}";
    //        var estatTextComprimit = estatText.CompressToBase64();
    //        var missatge = Encoding.UTF8.GetBytes(estatTextComprimit);

    //        var marcaDeTempsFinal = DateTime.Now;
    //        var temps = marcaDeTempsFinal - _marcaDeTemps;
    //        $@"Enviant estat {estat} ... (Durada: {temps.ToNaturalString()})".Mostrar(MostrarIcon.Information);
    //        await stream.WriteAsync(missatge, 0, missatge.Length);
    //        @"Enviat.".Mostrar(MostrarIcon.Information);
    //        _marcaDeTemps = marcaDeTempsFinal;

    //        var resposta = new byte[Helper.BufferSize];
    //        var bytesLlegits = await stream.ReadAsync(resposta, 0, resposta.Length);
    //        var respostaText = Encoding.UTF8.GetString(resposta, 0, bytesLlegits).DecompressFromBase64();

    //        //Trace.WriteLine($"Resposta del servidor: {respostaText}");

    //        var rt = respostaText.Split('^');
    //        if (rt.Length > 1)
    //        {
    //            if (bool.Parse(rt[1])) pitar.Invoke();
    //            if (bool.Parse(rt[2])) bloquejar.Invoke();
    //            if (bool.Parse(rt[3])) aturar.Invoke();
    //            if (bool.Parse(rt[4])) fiServidor.Invoke();
    //        }

    //        return rt.First();
    //    }

    //    private static void MostraError(Exception ex, TipusMissatge estat)
    //    {
    //        var nl = Environment.NewLine;
    //        var msg = $@"No es pot establir connexió amb el servidor{nl}{nl}Error:{ex.Message}";

    //        msg.ShowToast(10, ToastType.Error);
    //        ex.Mostrar();

    //        if (estat != TipusMissatge.Prova)
    //            Application.Exit();
    //    }
    //}
}