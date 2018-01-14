function getParameterDefinitions() {
  return [
      {name: 'width', type: 'float', initial: 80, caption: "取っ手の横幅"},
      {name: 'height', type: 'float', initial: 120, caption: "取っ手の縦幅"},
      {name: 'hutosa', type: 'float', initial: 10, caption: "太さ"}
  ];
}

function main(p) {
    let totte_sita = cube([p.width,p.hutosa,p.hutosa]).translate([0,0,0]);
    let totte_ue = cube([p.width,p.hutosa,p.hutosa]).translate([0,0,p.height]);    
    let totte_tunagi = cube([p.hutosa,p.hutosa,p.height-p.hutosa]).translate([p.width-p.hutosa,0,p.hutosa]);
    //let totte = union(totte_sita,totte_ue,totte_tunagi).translate([-p.width/2,-p.hutosa/2,0]);
    return union(totte_sita,totte_ue,totte_tunagi).translate([-p.width/2-25,-p.hutosa/2,0]);
}