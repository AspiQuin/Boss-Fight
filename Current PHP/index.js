let net;

const tf = require('@tensorflow/tfjs')

var canvas = document.getElementById('#canvas');

async function app() {
  console.log('Loading mobilenet..');

  // Load the model.
  net = await mobilenet.load();
  console.log('Successfully loaded model');


  //net.summary();

  model = keras.Sequential([
    keras.layers.Flatten(input_shape=(28, 28)),
    keras.layers.Dense(128, activation='relu'),
    keras.layers.Dense(10)
])

  //const webcam = await tf.data.webcam(canvas);
  while (true) {
    canvas = document.getElementById('#canvas');
    //context = canvas.getContext('2D')
    //img = new Image();
    //img = convertCanvasToImg(canvas);

    //img.width = 227;
    //img.height = 227;

    const result = await net.classify(canvas);

    //console.log(result[0]);

    //document.getElementById('console').innerText = 'test';//`prediction: ${result[0].className}\n probability: ${result[0].probability}`;
    // Dispose the tensor to release the memory.
    //img.dispose();

    // Give some breathing room by waiting for the next animation frame to
    // fire.
    await tf.nextFrame();
  }
}

function convertCanvasToImg(canvas) {
	var image = new Image();
	image.src = canvas.toDataURL("image/png");
	return image;
}



app();