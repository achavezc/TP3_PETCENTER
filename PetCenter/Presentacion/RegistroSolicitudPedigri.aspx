<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Solicitud.Master" AutoEventWireup="true" CodeBehind="RegistroSolicitudPedigri.aspx.cs" Inherits="PetCenter.Presentacion.RegistroSolicitudPedigri" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .windows{
            width:100%;
        }

        .table100{
            width:100%;
        }

        .grid100{
            width:100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="windows">
        <table class="table100">
            <tr>
                <td></td>
            </tr>
            <tr>
                <td><h2>Registro de Solicitud de Pedigrí</h2></td>
            </tr>
            <tr>
                <td>
                    <table class="table100" text="*">
                        <tr>
                            <td>
                                <h3>Datos de Cliente</h3>
                            </td>
                            <td>
                                <asp:Button ID="btn_BuscarCliente" runat="server" Text="Buscar" OnClick="btn_BuscarCliente_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>Nombre</td>
                            <td>
                                <asp:HiddenField ID="hid_codigoCliente" runat="server" />
                                <asp:TextBox ID="txt_nombreCliente" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
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
                </td>
            </tr>
            <tr>
                <td>
                    <table class="table100">
                        <tr>
                            <td>
                                <h3>Datos del Padre de la Mascota</h3>
                            </td>
                            <td>
                                <asp:Button ID="btn_buscarPadre" runat="server" Text="Buscar" OnClick="btn_buscarPadre_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>Nombre</td>
                            <td>
                                <asp:HiddenField ID="hid_codigoMascotaPadre" runat="server" />
                                <asp:TextBox ID="txt_PadreMascota" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
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
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="table100">
                        <tr>
                            <td>
                                <h3>Datos del Madre de la Madre</h3>
                            </td>
                            <td>
                                <asp:Button ID="btn_buscarMadre" runat="server" Text="Buscar" OnClick="btn_buscarMadre_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>Nombre</td>
                            <td>
                                <asp:HiddenField ID="hid_codigoMascotaMadre" runat="server" />
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
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>Comentarios</td>
                            <td>
                                <asp:TextBox ID="txtComentarios" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="table100">
                        <tr>
                            <td colspan="2"><h3>Datos de la Camada</h3></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btn_agregar_camada" runat="server" Text="Agregar Camada" OnClick="btn_agregar_camada_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="grid_camada" runat="server" CssClass="grid100"
                                            AutoGenerateColumns="false" DataKeyNames="">
                                    <Columns>
                                        <asp:BoundField DataField="codigo_mascota" Visible="false" />
                                        <asp:BoundField DataField="nombre_mascota" HeaderText="Nombre" />
                                        <asp:BoundField DataField="descripcion_raza" HeaderText="Raza" />
                                        <asp:BoundField DataField="edad" HeaderText="Edad" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btn_Guardar" runat="server" Text="Guardar" OnClick="btn_Guardar_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btn_cerrar" runat="server" Text="Cancelar" OnClick="btn_cerrar_Click"/>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
