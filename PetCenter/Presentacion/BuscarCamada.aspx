<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Solicitud.Master" AutoEventWireup="true" CodeBehind="BuscarCamada.aspx.cs" Inherits="PetCenter.Presentacion.BuscarCamada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .window {
            width:100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="window">
        <table>
            <tr>
                <td colspan="4">
                    <h3>Búsqueda de Camada</h3>
                </td>
            </tr>
            <tr>
                <td>Nombres</td>
                <td>
                    <asp:TextBox ID="txt_BuscaNombre" runat="server"></asp:TextBox>
                </td>
                <td>Genero</td>
                <td>
                    <asp:DropDownList ID="ddlGenero" runat="server">
                        <asp:ListItem Value="H" Selected="True">Todos</asp:ListItem>
                        <asp:ListItem Value="H">Hembra</asp:ListItem>
                        <asp:ListItem Value="M">Macho</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>Raza</td>
                <td>
                    <asp:DropDownList ID="ddl_raza" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btn_Buscar" runat="server" Text="Buscar" OnClick="btn_Buscar_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="grid_Camada" runat="server" AutoGenerateColumns="false"
                        DataKeyNames="codigo_mascota, codigo_genero">
                        <Columns>
                            <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelecion" runat="server" OnClick="javascript:SelectSingleRadiobutton(this.id)" />
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codigo_mascota" Visible="false" />
                            <asp:BoundField DataField="nombreMascota" HeaderText="Nombre" />
                            <asp:BoundField DataField="codigo_genero" Visible="false" />
                            <asp:BoundField DataField="genero" HeaderText="Genero" />
                            <asp:BoundField DataField="fechaNacimiento" HeaderText="Fecha Nacimiento" />
                            <asp:BoundField DataField="tamano" HeaderText="Tamaño" />
                            <asp:BoundField DataField="descripcionEspecie" HeaderText="Especie" />
                            <asp:BoundField DataField="nombreRaza" HeaderText="Raza" />
                            <asp:BoundField DataField="edadMeses" HeaderText="Edad" />
                            <asp:BoundField DataField="edadDias" HeaderText="Edad Días" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btn_agregar" runat="server" Text="Agregar" OnClick="btn_agregar_Click" />
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Button ID="btn_cerrar" runat="server" Text="Cancelar" OnClick="btn_cerrar_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
