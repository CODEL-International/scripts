#!/usr/bin/env python3
import minimalmodbus
import time
import os
import sys

n=len(sys.argv)

if n != 5:
  print("Arguments: COMx Baud Address_Array Timeout")
  quit()

addr = 1
instrument = minimalmodbus.Instrument(sys.argv[1], addr)  # port name, slave address (in decimal)  #COM11

instrument.serial.baudrate = sys.argv[2]  #9600       # Baud
instrument.serial.bytesize = 8
instrument.serial.parity   = minimalmodbus.serial.PARITY_NONE
instrument.serial.stopbits = 1
instrument.serial.timeout  = float(sys.argv[4]) #0.06          # seconds  0.06 = 60ms
instrument.mode = minimalmodbus.MODE_RTU   # rtu or ascii mode

addresses = sys.argv[3].split(',') #  [1,2,3,4] 
registers = [ 131]
names =     ["ET301"]
units =     ["%"]
info = [
"(% for Measured Percent)",
]

succ = [0,0,0,0]
fail = [0,0,0,0]
lastval = [0,0,0,0]


while 1:
  for addr in addresses:
    iaddr = int(addr)
    instrument.address = iaddr
    #print ("=== General info about address", addr, "===")
    #print (instrument)
    #print ("=== The registers for address", addr, "===")
    for i in range(len(registers)):
      try:
        value = instrument.read_register(registers[i], 2)
        #print (str(registers[i]).rjust(3), str(value).rjust(20), units[i].ljust(5), info[i])
        succ[iaddr-1] += 1
        lastval[iaddr-1] = value
      except:
        fail[iaddr-1] += 1
        
    time.sleep(0.1) # To avoid minimalmodbus.NoResponseError
  os.system('cls')
  print("ET301 Stress-o-Tron 5000")
  for addr in addresses:
    iaddr = int(addr)
    print (iaddr, ": ", succ[iaddr-1], "/", fail[iaddr-1], " ", lastval[iaddr-1])