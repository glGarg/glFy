#version 430



in vec2 fPos;

void main(){

	gl_FragColor = vec4(0.5 * (fPos + 1.), 1., 1.);

}