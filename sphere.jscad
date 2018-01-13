function getParameterDefinitions() {
  return [{ name: 'size', type: 'float', initial: 5, caption: "球の大きさ:" }];
}

function main(p) {
    return sphere(p.size).translate([-p.size/2,-p.size/2,0]);
}