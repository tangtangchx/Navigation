clear all, close all, clc
% x1 = [2 0;2 2;2 4;3 3];
% x2 = [0 3; -2 2;-1 -1;1 -2;3 -1];
% m1 = [2.25 2.25];
% m2 = [0.2 0.2];
x1 = [1 1;2 0;2 1;0 2;1 3];
x2 = [-1 2;0 0;-1 0;-1 -1;0 -2];
m1 = [1.2 1.4];
m2 = [-0.6 -0.2];
S1 = zeros(2,2);
S2 = zeros(2,2);
for i=1:4
    S1 = S1 + (x1(i,:)-m1)'*(x1(i,:)-m1);
end
for i=1:5
    S2 = S2 + (x2(i,:)-m2)'*(x2(i,:)-m2);
end
SW = S1+S2;
w = inv(SW)*(m1-m2)';
y1=x1*w;
y2=x2*w;
x=[-5:0.1:5];
y=x*w(1,1)/(-w(2,1))

y0 = (5*m1*w + 5*m2*w)/(5+5);

axis on;
plot(x,y);
xlabel('X');ylabel('Y');
axis([-5,5,-10,10]);
set(gca,'XTickMode','manual','XTick',[-5 0 5]);
set(gca,'YTickMode','manual','YTick',[-10 0 10]);grid