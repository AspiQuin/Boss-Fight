// JavaScript source code
const tf = require("@tensorflow/tfjs");

let net;

async function app() {
    console.log('Loading mobilenet..');

    // Load the model.
    net = await mobilenet.load();
    console.log('Successfully loaded model');

    // Make a prediction through the model on our image.
    const imgEl = document.getElementById('img');
    await tf.data.canvas();
    const result = await net.classify(imgEl);
    console.log(result);
}

app();