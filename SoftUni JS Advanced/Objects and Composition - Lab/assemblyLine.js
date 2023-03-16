function createAssemblyLine()
{
    return {
        hasClima(obj)
        {
            obj['temp'] = 21;
            obj['tempSettings'] = 21;
            obj['adjustTemp'] = function() {
                if(this.temp < this.tempSettings)
                {
                    this.temp++;
                }
                else if(this.temp > this.tempSettings)
                {
                    this.temp--;
                };
            }
        },
        hasAudio(obj)
        {
            obj['currentTrack'] = {
                name: null,
                artist: null,
            };
            obj['nowPlaying'] = function(){
                if(this.currentTrack !== null)
                {
                    console.log(`Now playing '${this.currentTrack.name}' by ${this.currentTrack.artist}`);
                }
            };
        },
        hasParktronic(obj)
        {
            obj['checkDistance'] = function(distance)
            {
                let result = '';
                if(distance < 0.5 && distance >= 0.25)
                {
                    result = 'Beep!';
                }
                else if(distance >= 0.1 && distance < 25)
                {
                    result = 'Beep! Beep!';
                }
                else if(distance < 0.1)
                {
                   result = 'Beep! Beep! Beep!';
                }

                console.log(result);
            }
        }
    }
}

const assemblyLine = createAssemblyLine();

const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};

assemblyLine.hasClima(myCar);
console.log(myCar.temp);
myCar.tempSettings = 18;
myCar.adjustTemp();
console.log(myCar.temp);

assemblyLine.hasAudio(myCar);
myCar.currentTrack = {
    name: 'Never Gonna Give You Up',
    artist: 'Rick Astley'
};
myCar.nowPlaying();

assemblyLine.hasParktronic(myCar);
myCar.checkDistance(0.4);
myCar.checkDistance(0.2);

console.log(myCar);