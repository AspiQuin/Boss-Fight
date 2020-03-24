<?php
	$servername = "ugrad.bitdegree.ca";
	$server_username = "erinwaldram";
	$server_password = "_Ps0qfH2NR";
	$dbname = "erinwaldram";
	
	//variables submitted by user
	$loginUser = $_POST["loginUser"];
	$loginPassword = $_POST["loginPassword"];
	
	//Create Connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbname);
	
	// Check connection
	if ($conn->connect_error){
		die("Connection failed: " . $conn->connect_error);
	}
	
	//else {
		//echo "Connected successfully";
	//}
	
	$loginPassword = md5($loginPassword);
	
	$sql = "SELECT password, screenname FROM BOSSFIGHTUSERS WHERE username = '". $loginUser . "'";
	
	$result = $conn-> query ($sql);
	//$userreturn = $conn -> query("SELECT screenname FROM BOOSSFIGHTUSERS WHERE username = '". $loginUser . "'");
	
	if ($result -> num_rows >0) {
		while ($row = $result -> fetch_assoc()) {
			if($row["password"] == $loginPassword) {
				echo $loginUser;
				
			}
			else {
				echo "Wrong credetials.";
			}
		}
	}
	else {
		echo "Username does not exist.";
	}
	$conn -> close();
	
?>