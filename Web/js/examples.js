
// dynamic table


function add(){
	
	//Element Values
	var id = document.getElementById("t_id").value;
	var name = document.getElementById("t_name").value;
	var major = document.getElementById("t_major").value;
	//Create Row Element
	var row = document.createElement("tr");
	
	//Create Row Cells
	var cell1 = document.createElement("td");
	var cell2 = document.createElement("td");
	var cell3 = document.createElement("td");
	
	//Append the cells to the row
	row.appendChild(cell1);
	row.appendChild(cell2);
	row.appendChild(cell3);
	
	//add text
	cell1.innerHTML = id;
	cell2.innerHTML = name;
	cell3.innerHTML = major;
	
	//append to the table
	document.getElementById("students").appendChild(row);
	
	count++;
	document.getElementById("counter").innerHTML = count;
}

//Add event listener to document
document.getElementById("add").addEventListener("click", add, false);
document.getElementById("exampleSpace").addEventListener("onMouseOver", hoverCounter, false);



