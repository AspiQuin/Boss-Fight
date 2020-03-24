
<!DOCTYPE html>
<html lang="en-us">
<head>	
	 	<meta charset="utf-8">
   	 	<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    	<title>Boss-Fight</title>
    	<link rel="shortcut icon" href="TemplateData/favicon.ico">
    	<link rel="stylesheet" href="TemplateData/style.css">
    	<script src="TemplateData/UnityProgress.js"></script>
    	<script src="Build/UnityLoader.js"></script>
    	<script>
      	var unityInstance = UnityLoader.instantiate("unityContainer", "Build/Boss-Fight-Build.json", {onProgress: UnityProgress});
    </script>
</head>
<body>
	<?php 
		session_start(); 
		
		if (!isset($_SESSION['username'])) {
		$_SESSION['msg'] = "You must log in first";
		include_once ('login.php'); // This will insure that login.php is included only once
	}
		if (isset($_GET['logout'])) {
		session_destroy();
		unset($_SESSION['username']);
		include_once ('login.php'); // This will insure that login.php is included only once
		$_SESSION['msg'] = "You must log in first";
	}
	?>
	

	
	<?php  if (!isset($_SESSION['username'])) : ?>
			<div>
				<h3>
					<?php echo $_SESSION['msg']; ?>
				</h3>
			</div>
		<?php elseif (isset($_SESSION['success'])) : ?>
			<div>
				<h3>
					<?php 
						echo $_SESSION['success']; 
						unset($_SESSION['success']);
					?>
				</h3>
			</div>
		<?php endif; ?>
	
	
	<?php  if (isset($_SESSION['username'])) : ?>
		<p>Welcome <strong><?php echo $_SESSION['username']; ?></strong></p>
		
	<div>
			
		<div class="webgl-content">
      	<div id="unityContainer" style="width: 720px; height: 400px"></div>
      	<div class="footer">
        	<div class="webgl-logo"></div>
        	<div class="fullscreen" onclick="unityInstance.SetFullscreen(1)"></div>
        	<div class="title">Boss-Fight</div>
      	</div>
   	 </div>
	
	</div>
		<!-- logged in user information -->
		<p> <a href="index.php?logout='1'" style="color: red;">logout</a> </p>
		
		<?php endif; ?>	
		

</body>
</html>