var submitButton = document.getElementById("btnSubmit3");

submitButton.addEventListener("click", function() {
var foodDropdown = document.getElementById("ddlSandwish");
var selectedFood = foodDropdown.value;
var foodPrice = parseFloat(foodDropdown.options[foodDropdown.selectedIndex].getAttribute("data-price"));

var sizeRadios = document.getElementsByName("rbSize3");
var selectedSize = "";
var sizePrice = 0;
for (var i = 0; i < sizeRadios.length; i++) {
  if (sizeRadios[i].checked) {
  selectedSize = sizeRadios[i].value;
  sizePrice = parseFloat(sizeRadios[i].getAttribute("data-price"));
  break;
  }
}

var totalPrice = foodPrice + sizePrice;

var resultElement = document.getElementById("result3");
var result = selectedFood + " (" + selectedSize + ") - Price: $" + totalPrice.toFixed(2);
resultElement.textContent =  result;
});