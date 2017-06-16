function jsNumbers(e) 
   {
      var evt = (e) ? e : window.event;
      var key = (evt.keyCode) ? evt.keyCode : evt.which;
      if(key != null) 
      {
          key = parseInt(key, 10);
          if((key < 48 || key > 57) && (key < 96 || key > 105)) 
          {
              if(!jsIsUserFriendlyChar(key, "Numbers"))
              {
                  return false;
              }
          }
          else 
          {
              if(evt.shiftKey)
              {
                  return false;
              }
          }
      }
      return true;
   }        
   
   //-------------------------------------------
   // Function to only allow decimal data entry
   //-------------------------------------------
   function jsDecimals(e)
   {
      var evt = (e) ? e : window.event;
      var key = (evt.keyCode) ? evt.keyCode : evt.which;
      if(key != null) 
      {
          key = parseInt(key, 10);
          if((key < 48 || key > 57) && (key < 96 || key > 105)) 
          {
              if(!jsIsUserFriendlyChar(key, "Decimals"))
              {
                  return false;
              }
          }
          else 
          {
              if(evt.shiftKey)
              {
                  return false;
              }
          }
      }
      return true;
   }        
   
   //------------------------------------------
   // Function to check for user friendly keys
   //------------------------------------------
   function jsIsUserFriendlyChar(val, step) 
   {
      // Backspace, Tab, Enter, Insert, and Delete
      if(val == 8 || val == 9 || val == 13 || val == 45 || val == 46)
      {
          return true;
      }
      // Ctrl, Alt, CapsLock, Home, End, and Arrows
      if((val > 16 && val < 21) || (val > 34 && val < 41))
      {
          return true;
      }
      if (step == "Decimals")
      {
          if(val == 190 || val == 110)
          {
              return true;
          }
      }
      // The rest
      return false;
   }     
   
   function fnUIblock(){
       $.blockUI({ message: '<h1 style="margin-top:14px;font-size:25px"> Procesando..</h1>' });
   }
   
function Fc_Popup_jquery(url,ancho,alto,nombre,nombre_div) 

{

$(nombre_div).dialog({ title: nombre,close:function(){$('#idconsulta').remove();},

width : ancho,
height : alto, 
modal: true, 
draggable: true, 
resizable: true,
position: 'center'});

$(nombre_div).html("<iframe id='idconsulta' frameBorder='0' scrolling='yes' style ='border:0;margin-left:-30px;borderStyle=none' width='" + ancho + "' height='" + alto + "' marginheight='0' marginwidth='0' src='" + url + "'></iframe>");

};

function Fc_Popup_jquery_3(url, ancho, alto, nombre, nombre_div) {

    $(nombre_div).dialog({
        title: nombre, close: function () { $('#idconsulta_3').remove(); },
        width: ancho,
        height: alto,
        modal: true,
        draggable: true,
        resizable: true,
        position: 'center'
    });
    $(nombre_div).html("<iframe id='idconsulta_3' frameBorder='0' scrolling='yes' style ='border:0;borderStyle=none' width='" + ancho + "' height='" + alto + "' marginheight='0' marginwidth='0' src='" + url + "'></iframe>");

}

function fnCerrarDivConsulta3_parametro(dato1, dato2, dato3, dato4, dato5,Formulario) {

    var frame = document.getElementById('idconsulta');
    var frameDoc = frame.contentWindow.document;
    
    if (Formulario == 'CLIENTE') {
        frameDoc.forms[0].txt_dni.value = dato1;
        frameDoc.forms[0].txt_nombre.value = dato2;
        frameDoc.forms[0].txt_apellidos.value = dato3;
        frameDoc.forms[0].id_codigo_cliente.value = dato4;
    }

    if (Formulario == 'MASCOTA') {
        frameDoc.forms[0].txt_nombre_mascota.value = dato1;
        frameDoc.forms[0].txt_raza.value = dato2;
        frameDoc.forms[0].txt_edad.value = dato3;
        frameDoc.forms[0].id_codigo_mascota.value = dato4;
    }

    $("#divConsulta3").html("");
    $("#divConsulta3").dialog("destroy");

}

function fnCerrarDivConsulta3() {
    $("#divConsulta").html("");
    $("#divConsulta").dialog("destroy");
}