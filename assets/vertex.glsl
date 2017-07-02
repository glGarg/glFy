#version 430


layout(location = 0) in vec2 pos;


out vec2 fPos;

void main(){

	fPos = pos;
	gl_Position = vec4(pos, 0., 1.);

}