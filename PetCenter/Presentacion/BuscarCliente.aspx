<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Solicitud.Master" AutoEventWireup="true" CodeBehind="BuscarCliente.aspx.cs" Inherits="PetCenter.Presentacion.BuscarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function SelectSingleRadiobutton(rdbtnid) {
            var rdBtn = document.getElementById(rdbtnid);
            var rdBtnList = document.getElementsByTagName("input");
            for (i = 0; i < rdBtnList.length; i++) {
                if (rdBtnList[i].type == "radio" && rdBtnList[i].id != rdBtn.id) {
                    rdBtnList[i].checked = false;
                }
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div style="width:100%;">
        <table>
            <tr>
                <td>
                    <h3>Búsqueda de Cliente</h3>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>Tipo de Documento</td>
                            <td>
                                <asp:DropDownList ID="ddl_tipoDocumento" runat="server">
                                    <asp:ListItem Value="0">Todos</asp:ListItem>
                                    <asp:ListItem Value="1">Dni</asp:ListItem>
                                    <asp:ListItem Value="3">Carnet Extranjeria</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>Numero de Documento</td>
                            <td>
                                <asp:TextBox ID="txt_numeroDocumento" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>Nombres</td>
                            <td>
                                <asp:TextBox ID="txt_Nombre" runat="server"></asp:TextBox>
                            </td>
                            <td>Apellido Paterno</td>
                            <td>
                                <asp:TextBox ID="txt_ApPaterno" runat="server"></asp:TextBox>
                            </td>
                            <td>Apellido Materno</td>
                            <td>
                                <asp:TextBox ID="txt_ApMaterno" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:Button ID="btn_Buscar" runat="server" Text="Buscar" OnClick="btn_Buscar_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grid_Clientes" runat="server" AutoGenerateColumns="false" OnRowCreated="grid_Clientes_RowCreated" ShowHeaderWhenEmpty="True"
                                    DataKeyNames="codigo_cliente">
                        <HeaderStyle BackColor="#663300" ForeColor="#ffffff"/>
                        <RowStyle BackColor="#e7ceb6"/>
                        <Columns>
                            <asp:TemplateField>
                            <ItemTemplate>
                                <asp:RadioButton ID="rbSeleccion" runat="server" OnClick="javascript:SelectSingleRadiobutton(this.id)" />
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="codigo_cliente" Visible="false"/>
                            <asp:BoundField DataField="nombres" HeaderText="Nombres"/>
                            <asp:BoundField DataField="apellidoPaterno" HeaderText="Apellido Paterno"/>
                            <asp:BoundField DataField="apellidoMaterno" HeaderText="Apellido Materno"/>
                            <asp:BoundField DataField="tipoDocumento" Visible="false" />
                            <asp:BoundField DataField="descrDocumento" HeaderText="Tipo Documento"/>
                            <asp:BoundField DataField="numeroDocumento" HeaderText="Número de Documento"/>
                            <asp:BoundField DataField="direccion" HeaderText="Dirección"/>
                            <asp:BoundField DataField="telefono" HeaderText="Telefono"/>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btn_agregar" runat="server" Text="Agregar" OnClick="btn_agregar_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btn_cerrar" runat="server" Text="Cancelar" OnClick="btn_cerrar_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                
            </tr>
        </table>
    </div>
</asp:Content>
