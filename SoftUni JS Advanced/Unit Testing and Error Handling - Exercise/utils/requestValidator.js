function validator(obj) {
    let uriPattern = /(^[a-z0-9.]+\b$)/;
    let specialSym = ['<', '>', '\'', '&', ',', '"'];
    let correctMethod = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let correctVersion =['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];

    let method = obj['method'];
    let isCorrectMethod = false;
    for (let i = 0; i < correctMethod.length; i++) {
        let current = correctMethod[i];
        if (method === current) {
            isCorrectMethod = true;
            break;
        }
    }

    if (!isCorrectMethod) {
        throw new Error(`Invalid request header: Invalid Method`);
    }

    let uri = obj['uri'];
    let match = uriPattern.exec(uri);
    if (match === null || uri === undefined) {
        throw new Error('Invalid request header: Invalid URI')
    }

    let version = obj['version'];
    let isCorrectVersion = false;
    for (let i = 0; i < correctVersion.length; i++) {
        let current = correctVersion[i];
        if (version === current) {
            isCorrectVersion = true;
            break;
        }
    }

    if(!isCorrectVersion){
        throw new Error('Invalid request header: Invalid Version');
    }

    let message = obj['message'];
    
    let isCorrectMessage = true;
    for (let i = 0; i < specialSym.length; i++) {
        let current = specialSym[i];
        if (message.includes(current)) {
            isCorrectMessage = false;
            break;
        }
    }

    if(!isCorrectMessage || message === undefined){
        throw new Error('Invalid request header: Invalid Message');
    }

    return obj;
}

validator({
    method: 'POST',
    uri: 'home.bash',
    version: 'HTTP/2.0'
})

module.exports = { validator };