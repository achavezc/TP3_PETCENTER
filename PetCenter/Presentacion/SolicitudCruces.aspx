<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Solicitud.Master" AutoEventWireup="true" CodeBehind="SolicitudCruces.aspx.cs" Inherits="PetCenter.Presentacion.SolicitudCruces" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .windows {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="windows">
        <table>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td>
                    <h2>Registro de Solicitud de Cruces</h2>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
        </table>

        <%--Datos Ciente 1--%>
        <table>
            <tr>
                <td>
                    <h3>Datos de Cliente 1</h3>
                </td>
                <td>
                    <asp:Button ID="btn_BuscarCliente" runat="server" Text="Buscar" OnClick="btn_BuscarCliente_Click"  />
                </td>
            </tr>
            <tr>
                <td>Nombre</td>
                <td>
                    <asp:TextBox ID="txt_nombreCliente" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td>Apellido Paterno</td>
                <td>
                    <asp:TextBox ID="txt_ApellidoPaterno" runat="server"></asp:TextBox>
                </td>
                <td>Apellido Materno</td>
                <td>
                    <asp:TextBox ID="txt_ApellidoMaterno" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Dirección</td>
                <td>
                    <asp:TextBox ID="txt_Direccion" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
        </table>

        <%--Datos de Mascota de Cliente 1--%>

        <table>
            <tr>
                <td>
                    <h3>Datos del Mascota</h3>
                </td>
                <td>
                    <asp:Button ID="btn_buscarPadre" runat="server" Text="Buscar"  />
                </td>
            </tr>
            <tr>
                <td>Nombre</td>
                <td>
                    <asp:TextBox ID="txt_PadreMascota" runat="server"></asp:TextBox></td>
                <td>&nbsp;
                </td>
            </tr>

            <tr>
                <td>Raza</td>
                <td>
                    <asp:TextBox ID="txt_razaPadre" runat="server"></asp:TextBox>
                </td>
                <td>Edad</td>
                <td>
                    <asp:TextBox ID="txt_edadPadre" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td></td>
            </tr>
        </table>

        <table>
            <tr>
                <td></td>
            </tr>
        </table>

          <%--Datos Ciente 2--%>
        <table>
            <tr>
                <td>
                    <h3>Datos de Cliente 2</h3>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Buscar"  />
                </td>
            </tr>
            <tr>
                <td>Nombre</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td>Apellido Paterno</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>Apellido Materno</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Dirección</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
        </table>


        <%--Datos Mascota de Cliente 2--%>
        <table>
            <tr>
                <td>
                    <h3>Datos de Mascota</h3>
                </td>
                <td>
                    <asp:Button ID="btn_buscarMadre" runat="server" Text="Buscar"  />
                </td>
            </tr>
            <tr>
                <td>Nombre</td>
                <td>
                    <asp:TextBox ID="txt_MadreMascota" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Raza</td>
                <td>
                    <asp:TextBox ID="txt_razaMadre" runat="server"></asp:TextBox>
                </td>
                <td>Edad</td>
                <td>
                    <asp:TextBox ID="txt_edadMadre" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>

        <table>
            <tr>
                <td></td>
            </tr>
        </table>


        <table>

            <tr>
                <td>
                    <asp:Button ID="btn_Guardar" runat="server" Text="Guardar" />
                </td>
                <td>
                    <asp:Button ID="btn_cerrar" runat="server" Text="Cancelar" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

