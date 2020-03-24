<?php
	$servername = "ugrad.bitdegree.ca";
	$server_username = "erinwaldram";
	$server_password = "_Ps0qfH2NR";
	$dbname = "erinwaldram";
	
	//Create Connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbname);
	
	// Check connection
	if ($conn->connect_error){
		die("Connection failed: " . $conn->connect_error);
	}
	
	//else {
		//echo "Connected successfully";
	//}
	
	
	$sql = "SELECT screenname, username FROM BOSSFIGHTUSERS";
	$result = $conn-> query ($sql);
	
	if ($result -> num_rows >0) {
		while ($row = $result -> fetch_assoc()) {
			echo "screenname: ". $row["screenname"]. " - username: " . $row["username"] . "<br>";
		}
	}
	else {
		echo "0 results";
	}
	$conn -> close();
	
?>