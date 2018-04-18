
function myFunction() {
    // Declare variables 
    var input, filter, table, tr, td, i, index, counter;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");
    counter = 0; // if there is none Name or Telephone, then this is used to search by lastName

    loop();

    function loop() {
        //searching filter (by Name or by Number)
        if (index != 1) { // if index is not 1 then this wont go in
            if ((input.value.indexOf("-") <= -1) && isNaN(input.value)) { // is hasn't been written "-", and hasn't been written a number
                index = 0;
            }
            else {
                index = 2;
            }
        }

        // Loop through all table rows, and hide those who don't match the search query
        for (i = 1; i < tr.length; i++) {
            td = tr[i].getElementsByTagName("td")[index];
            if (td) {
                if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                    tr[i].style.display = ""; // display stays the same way it was
                } else {
                    tr[i].style.display = "none"; // display is disabled
                    counter = counter + 1; // increase counter
                    if (counter == tr.length - 1) {
                        index = 1;
                        counter = 0; // restart counter
                        loop(); // recall the loop to take the index=1 and start to search by lastname
                    }
                }
            }
        }
    }
}
