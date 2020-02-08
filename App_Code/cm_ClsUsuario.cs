using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cm_ClsUsuario
/// </summary>
public class cm_ClsUsuario
{
    private string ced_User;
    private string nom_User;
    private string ape_User;
    private string edad_User;
    private string tlf_User;
    private decimal pesoI_User;
    private decimal alturaI_User;
    private int tip_Usu; //Administrador 2=Usuario
    private int act_Usu; //1 = activo 2 = no activo

    public cm_ClsUsuario()
    {
    }

    public cm_ClsUsuario(string cedula, string nombre, string apellido, string edad, string tlf, decimal pesoI, decimal alturaI, int tipoU, int actU)
    {
        this.ced_User = cedula;
        this.nom_User = nombre;
        this.ape_User = apellido;
        this.edad_User = edad;
        this.tlf_User = tlf;
        this.pesoI_User = pesoI;
        this.alturaI_User = alturaI;
        this.tip_Usu = tipoU;
        this.act_Usu = actU;
    }

    public cm_ClsUsuario(string cedula)
    {
        this.ced_User = cedula;
    }

    public cm_ClsUsuario(string cedula, string nombre, int tipoU, int actU)
    {
        this.ced_User = cedula;
        this.nom_User = nombre;
        this.tip_Usu = tipoU;
        this.act_Usu = actU;
    }

    //getter and setter
    public string Ced_User
    {
        get { return ced_User; }
        set { ced_User = value; }
    }

    public string Nom_User
    {
        get { return nom_User; }
        set { nom_User = value; }
    }

    public string Ape_User
    {
        get { return ape_User; }
        set { ape_User = value; }
    }

    public string Edad_User
    {
        get { return edad_User; }
        set { edad_User = value; }
    }

    public string Tlf_User
    {
        get { return tlf_User; }
        set { tlf_User = value; }
    }

    public decimal PesoI_User
    {
        get { return pesoI_User; }
        set { pesoI_User = value; }
    }

    public decimal AlturaI_User
    {
        get { return alturaI_User; }
        set { alturaI_User = value; }
    }

    public int Tip_Usu
    {
        get { return tip_Usu; }
        set { tip_Usu = value; }
    }

    public int Act_Usu
    {
        get { return act_Usu; }
        set { act_Usu = value; }
    }
}