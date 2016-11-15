Z=[];
y=[];

%% System Information
AC_line_info_struct=load('AC_line_info_true_value_Zy.mat');
AC_line_info = AC_line_info_struct.AC_line_info;

line_number = 1;

line_name=['line_' ,num2str(line_number), '_true_positive_sequence.mat'];
VI_origin_struct=load(line_name);
VI = VI_origin_struct.VI_true_set;

baseZ = (345000)^2/100000000;
Z_true = AC_line_info(line_number,10)*baseZ;
y_true = AC_line_info(line_number,11)/baseZ;

%% Real-time Impedance Calculation
for idx = 1:size(VI,1)
        
    V1 = VI(idx,1);
    I1 = VI(idx,2);
    V2 = VI(idx,3);
    I2 = VI(idx,4);
    
    Z = [Z; (V1.*V1-V2.*V2)./(I1.*V2-I2.*V1)];
    
    y = [y; 1i*imag((I1+I2)./(V1+V2))];
    
end

%% Results demonstration
figure%1 Impedance
subplot(2,1,1)
plot(1:size(Z,1),real(Z),'-');
grid on
hold on
plot(1:size(Z,1),real(Z_true),'r-');
grid on
legend('Calculated Impedance Real','True Impedance Real');

subplot(2,1,2)
plot(1:size(Z,1),imag(Z),'-');
hold on
plot(1:size(Z,1),imag(Z_true),'r-');
grid on
legend('Calculated Impedance Imag','True Impedance Imag');

figure%2 Susceptance
plot(1:size(y,1),imag(y),'-');
hold on
plot(1:size(y,1),imag(y_true),'r-');
grid on
legend('Calculated Susceptance','True Susceptance');

