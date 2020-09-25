function DynamicText() {
  var division = document.createElement('DIV');
  division.innerHTML = DynamictextBox("");
  document.getElementById("divToRepeat").appendChild(division);
}

function DynamictextBox(value){
  return '<div class="row" id="divToRepeat">'
 
}