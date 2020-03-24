<?php
	$servername = "ugrad.bitdegree.ca";
	$server_username = "erinwaldram";
	$server_password = "_Ps0qfH2NR";
	$dbname = "erinwaldram";
	
	//variables submitted by user
	$loginUser = $_POST["loginUser"];
	$loginPassword = $_POST["loginPassword"];
	$loginPassword2 = $_POST["loginPassword2"];
	$loginScreen = $_POST["loginScreen"];
	
	
	//Create Connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbname);
	
	// Check connection
	if ($conn->connect_error){
		die("Connection failed: " . $conn->connect_error);
	}
	
	$loginPassword = md5($loginPassword);
	$loginPassword2 = md5($loginPassword2);
	
	$sql = "SELECT username FROM BOSSFIGHTUSERS WHERE username = '". $loginUser . "'";
	
	$result = $conn-> query ($sql);
	//$userreturn = $conn -> query("SELECT screenname FROM BOOSSFIGHTUSERS WHERE username = '". $loginUser . "'");
	
	if ($result -> num_rows >0) {
	//Tell user that that name is already taken
		echo "Username is already taken.";
	}
	else {
	
		if ($loginPassword != $loginPassword2)
		{
			echo "Error: Passwords do not match.";
		}
		
		else{
			//Inster the user and password into the database
			$sql2 = "INSERT INTO BOSSFIGHTUSERS (username, password, screenname) VALUES ('" . $loginUser . "', '" . $loginPassword . "' , '" . $loginScreen . "')";
		
			if($conn -> query($sql2) === TRUE) {
				echo $loginUser;
			}
			else {
				echo "Error: " . $sql2 . "<br>" . $conn->error;
			}
		}
	}
	$conn -> close();
	
?>