<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Solicitud.Master" AutoEventWireup="true" CodeBehind="ConsultaSolicitud.aspx.cs" Inherits="PetCenter.Presentacion.ConsultaSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .grid {
            width:100%;

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <h3>Consultar Solicitudes</h3>
                </td>
                </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_crearSolicitud" runat="server" Text="Crear Solicitud" OnClick="btn_crearSolicitud_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>Número de Solicitud</td>
                            <td>
                                <asp:TextBox ID="txt_numSolicitud" runat="server"></asp:TextBox>
                            </td>
                            <td>Fecha de Inicio</td>
                            <td>
                                <asp:TextBox ID="txt_fechaInicio" runat="server"></asp:TextBox>
                            </td>
                            <td>Fecha de Fin</td>
                            <td>
                                <asp:TextBox ID="txt_fechaFin" runat="server"></asp:TextBox>
                            </td>
                            <td>Estado</td>
                            <td>
                                <asp:DropDownList ID="comb_estado" runat="server">
                                    <asp:ListItem Value="0" Text="Todos"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Pendiente"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Aprobada"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Rechazada"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>Nombres</td>
                            <td>
                                <asp:TextBox ID="txt_nombres" runat="server"></asp:TextBox>
                            </td>
                            <td>Apellido Paterno</td>
                            <td>
                                <asp:TextBox ID="txt_ApPaterno" runat="server"></asp:TextBox>
                            </td>
                            <td>Apellido Materno</td>
                            <td>
                                <asp:TextBox ID="txt_ApMaterno" runat="server"></asp:TextBox>
                            </td>
                            <td>Tipo de Documento</td>
                            <td>
                                <asp:DropDownList ID="comb_TipoDoc" runat="server">
                                    <asp:ListItem Value="0">Todos</asp:ListItem>
                                    <asp:ListItem Value="1">Dni</asp:ListItem>
                                    <asp:ListItem Value="3">Carnet Extranjeria</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>Número de Documento</td>
                            <td>
                                <asp:TextBox ID="txt_numDocumento" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_Buscar" runat="server" Text="Buscar" OnClick="btn_Buscar_Click" />
                </td>
            </tr>
            <tr>
            <td>
                <asp:GridView ID="grid_Solicitudes" runat="server" CssClass="grid" AutoGenerateColumns="false">
                    <HeaderStyle BackColor="#663300" ForeColor="#ffffff"/>  
                    <RowStyle BackColor="#e7ceb6"/>
                    <Columns>
                        <asp:BoundField DataField="numero_solicitud" HeaderText="Nro. Solicitud"/>
                        <asp:BoundField DataField="fechaSolicitud" HeaderText="Fecha"/>
                        <asp:BoundField DataField="tipoSolicitud" HeaderText="Tipo"/>
                        <asp:BoundField DataField="estadoSolicitud" HeaderText="Estado"/>
                        <asp:BoundField DataField="codigo_cliente" Visible="false"/>
                        <asp:BoundField DataField="nombres" HeaderText="Nombres"/>
                        <asp:BoundField DataField="apellidoPaterno" HeaderText="Ap. Paterno"/>
                        <asp:BoundField DataField="apellidoMaterno" HeaderText="Ap. Materno"/>
                        <asp:BoundField DataField="descrDocumento" HeaderText="Tipo Documento"/>
                        <asp:BoundField DataField="numeroDocumento" HeaderText="Nro. Documento"/>
                        <asp:BoundField DataField="Mascota_Padre" HeaderText="Padre"/>
                        <asp:BoundField DataField="Mascota_Madre" HeaderText="Madre"/>

                    </Columns>
                </asp:GridView>
            </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_volver" runat="server" Text="Volver" OnClick="btn_volver_Click"  />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
