
<!DOCTYPE html>
<html lang="en-us">
<head>	
		<link rel="stylesheet" href="style.css">
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
	<!-- Load the latest version of TensorFlow.js -->
	<script src="https://cdn.jsdelivr.net/npm/@tensorflow/tfjs"></script>
	<!-- Load the latest version of mobilenet trained on image dataset -->
	<script src="https://cdn.jsdelivr.net/npm/@tensorflow-models/mobilenet"></script>
</head>
<body>

	<div>
		<h2>BOSS-FIGHT</h2>
	<div>

<main>		
	<div>
			
		//BECUASE YOU HAVE TO BE LOGGED IN TO PLAY, YOU SHOULD IN THEORY BE 
		//ABLE TO RUN A COROUTINE IN HERE?
		
		<div class="webgl-content">
      	<div id="unityContainer" style="width: 1300px; height: 700px"></div>
      	<div class="footer">
        	<div class="fullscreen" onclick="unityInstance.SetFullscreen(1)"></div>
      	</div>
   	 </div>
	</div>
</main>	
	
<script src="index.js"></script>
</body>
</html>