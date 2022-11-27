// Cache the label for later use.
var label = document.getElementById('label');
var start = document.getElementById('start');
var stop = document.getElementById('stop');
var mp3player = document.getElementById('mp3player');
mp3player.style.visibility = "hidden";
var src = mp3player.src;
stop.style.visibility = "hidden";




// Setup the sounds to be used.
var sound1 = new Howl({

    src: [src],
  html5: true
});



// Enable the start button when the sounds have loaded.
sound1.once('load', function() {
  //start.removeAttribute('disabled');
  //start.innerHTML = 'BEGIN CORE TESTS';
  
});

// Define the tests to run.
var id;
var tests = [
   function(fn) {
    id = sound1.play();


   stop.style.visibility ="visible";
  },

  function(fn) {
    sound1.pause(id);


    setTimeout(fn, 1500);
  },

  function(fn) {
    sound1.play(id);


    setTimeout(fn, 2000);
  },

  function(fn) {
    sound1.stop(id);

    setTimeout(fn, 1500);
  },

  function(fn) {
    sound1.play(id);

    setTimeout(fn, 2000);
  },






  function(fn) {
    sound1.mute(true, id);

    setTimeout(fn, 1500);
  },

  function(fn) {
    sound1.mute(false, id);

    setTimeout(fn, 2000);
  },



  function(fn) {
    sound1.seek(0, id);

    setTimeout(fn, 2000);
  },

  function(fn) {
    id = sound1.play();

    setTimeout(fn, 2000);
  },

  function(fn) {
    sound1.mute(true);

    setTimeout(fn, 1500);
  },

  function(fn) {
    sound1.mute(false);

    setTimeout(fn, 2000);
  },

  function(fn) {
    sound1.volume(0.5);

    setTimeout(fn, 2000);
  },

  function(fn) {
    sound1.fade(0.5, 0, 2000);

    sound1.once('fade', function() {
      if (sound1._onfade.length === 0) {
        fn();
      }
    });
  },

  function(fn) {
    sound1.fade(0, 1, 2000);

    sound1.once('fade', function() {
      if (sound1._onfade.length === 0) {
        fn();
      }
    });
  },

  function(fn) {
    sound1.stop();

    setTimeout(fn, 1500);
  },

  function(fn) {
    id = sound2.play('beat');

    setTimeout(fn, 2000);
  },

  function(fn) {
    sound2.pause(id);

    setTimeout(fn, 1000);
  },

  function(fn) {
    sound2.play(id);

    setTimeout(fn, 1500);
  },

  function(fn) {
    var sounds = ['one', 'two', 'three', 'four', 'five'];
    for (var i=0; i<sounds.length; i++) {
      setTimeout(function(i) {
        sound2.play(sounds[i]);
      }.bind(null, i), i * 500);
    }

    setTimeout(fn, 3000);
  },

  function(fn) {
    var sprite = sound2.play('one');
    sound2.loop(true, sprite);

    setTimeout(function() {
      sound2.loop(false, sprite);
      fn();
    }, 3000);
  },

  function(fn) {
    sound2.fade(1, 0, 2000, id);

    sound2.once('fade', function() {
      fn();
    });
  }
];

// Create a method that will call the next in the series.
var chain = function(i) {
  return function() {
    if (tests[i]) {
      tests[i](chain(++i));
    } else {
      document.getElementById('logo').style.display = 'none';

      label.style.color = '#74b074';

      // Wait for 5 seconds and then go back to the tests index.
      setTimeout(function() {
        window.location = './';
      }, 5000);
    }
  };
};
start.addEventListener('click', function() {
  tests[0](chain(1));
  start.style.visibility = 'hidden';
   stop.style.visibility ="visible";
}, false);
// Listen to a click on the button to being the tests.
stop.addEventListener('click', function() {
     sound1.stop();
 stop.style.visibility ="hidden";
   start.style.visibility = 'visible';
}, false);