
var submitButton = document.getElementById("btnSubmit");

submitButton.addEventListener("click", function() {
var foodDropdown = document.getElementById("ddlSnacks");
var selectedFood = foodDropdown.value;
var foodPrice = parseFloat(foodDropdown.options[foodDropdown.selectedIndex].getAttribute("data-price"));

var sizeRadios = document.getElementsByName("rbSize");
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

var resultElement = document.getElementById("result");
var result = selectedFood + " (" + selectedSize + ") - Price: $" + totalPrice.toFixed(2);
resultElement.textContent =  result;
});

