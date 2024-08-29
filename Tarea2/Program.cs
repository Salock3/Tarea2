using System;
// Interfaz de Mensaje original
public interface OgMensaje
{
    string ObtenerContenido();
}
//Clase del Mensaje Original
public class Mensa:OgMensaje
{
    private string conte;
    public Mensa(string contenido)
    {
        conte = contenido;
    }
    public string ObtenerContenido() { return conte; }
}

//Consola Main
public abstract class DecoradorMensaje : OgMensaje 
{
    protected OgMensaje mensa;
    public DecoradorMensaje(OgMensaje mensa)
    {
        this.mensa = mensa;
    }
    public abstract string ObtenerContenido();
}
//Mensaje Encriptado
public class EncriptarMensaje : DecoradorMensaje
{
    public EncriptarMensaje(OgMensaje mensa) : base(mensa)
    {
    } 
    public override string ObtenerContenido()
    {
        // Encriptacion de mensaje Ejemplo
        return $"[Encriptado]{mensa.ObtenerContenido()}";
    }
}
// Mensaje comprimido
public class ComprimirMensaje : DecoradorMensaje
{
    public ComprimirMensaje(OgMensaje mensa) : base(mensa)
    { }
    // Imprime el mensaje comprimido
    public override string ObtenerContenido()
    {
        return $"[Comprimido] {mensa.ObtenerContenido()}";
    }
}

// Firmado del mensaje
public class FirmarMensaje : DecoradorMensaje
{
    public FirmarMensaje(OgMensaje mensa) : base(mensa)
    { }
    //Imprime la firma
    public override string ObtenerContenido()
    {
        return $"{mensa.ObtenerContenido()}[Contrato firmado]";
    }
}

//Implementacion del codigo
public class Programa
{
    public static void Main(string[] args)
    {
        //Crea el mensaje original
        OgMensaje mensa = new Mensa("Hola, Adios");
        //Aplica la encriptacion
        OgMensaje MensajeEncriptado = new EncriptarMensaje(mensa);
        Console.WriteLine(MensajeEncriptado.ObtenerContenido());
        //Aplica la compresion
        OgMensaje MensajeComprimido = new ComprimirMensaje(MensajeEncriptado);
        Console.WriteLine(MensajeComprimido.ObtenerContenido());
        //Aplica la firma
        OgMensaje MensajeFirmado = new FirmarMensaje(MensajeComprimido);
        Console.WriteLine(MensajeFirmado.ObtenerContenido());

    }
}

