function DynamicText() {
  var division = document.createElement('DIV');
  division.innerHTML = DynamictextBox("");
  document.getElementById("divToRepeat").appendChild(division);
}

function DynamictextBox(value){
  return '<div><input type="text" name="dyntxt" /><input type="button" onclick="ReTextBox(this)" value="Remove" /></div>';
}
function ReTextBox(div) {
  document.getElementById("divToRepeat").removeChild(div.parentNode.parentNode);
}