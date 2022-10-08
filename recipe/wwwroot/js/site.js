function addIngredient() {
    var currentValue = document.getElementById("currentIngredient").value;
    document.getElementById("ingredientDiv").innerHTML += `<input value="${currentValue}" name="Ingredients" asp-for="Ingredients" class="inp2 form-control">`;
    document.getElementById("currentIngredient").value ="";
}
function addMethod() {
    var currentValue = document.getElementById("currentMethod").value; 
    document.getElementById("methodDiv").innerHTML += `<input  value="${currentValue}" name="Methods" asp-for="Methods" class="inp2 form-control">`;
    document.getElementById("currentMethod").value = "";
}
function addIngredientUpdate() {
    var currentValue = document.getElementById("currentIngredient").value;
    document.getElementById("ingredientDiv").innerHTML += `<input value="${currentValue}" name="Ingredients" asp-for="Ingredients" class="inp2 form-control">
                                                          <span onclick="deleteItem('ing-@i')" class="btn btn-sm btn-danger">X</span>`;
    document.getElementById("currentIngredient").value = "";
}
function addMethodUpdate() {
    var currentValue = document.getElementById("currentMethod").value;
    document.getElementById("methodDiv").innerHTML += `<input  value="${currentValue}" name="Methods" asp-for="Methods" class="inp2 form-control">
                                                        <span onclick="deleteItem('ing-@i')" class="btn btn-sm btn-danger">X</span>`;
    document.getElementById("currentMethod").value = "";
}
function deleteItem(itemId) {
    const element = document.getElementById(`${itemId}`)
    element.remove();
    return false;
}
function filter() {
    $("form").submit()
}
