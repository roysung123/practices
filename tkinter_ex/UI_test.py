import tkinter as tk
import glob
from PIL import Image,ImageTk
import random

#--------------------------------------------------------------------------------
def resize(w, h, w_box, h_box, pil_image):  
  ''' 
  resize a pil_image object so it will fit into 
  a box of size w_box times h_box, but retain aspect ratio
  '''  
  f1 = 1.0*w_box/w # 1.0 forces float division in Python2  
  f2 = 1.0*h_box/h  
  factor = min([f1, f2])  
  #print(f1, f2, factor) # test  
  # use best down-sizing filter  
  width = int(w*factor)  
  height = int(h*factor)  
  return pil_image.resize((width, height), Image.ANTIALIAS)  

def imgbig(event):
  event.widget.config(image=imor)
  window.update()
  canvas.config(scrollregion=(0,0,frame.winfo_width(),frame.winfo_height()))

def imgsml(event):
  event.widget.config(image=img)
  window.update()
  canvas.config(scrollregion=(0,0,frame.winfo_width(),frame.winfo_height()))

def recount():
  window.update()
  global itemcount
  global columncount
  global bb
  global ii
  scht = searc.get()
  itemcount = int(itemcountsp.get())
  columncount = int(columncountsp.get())
  for w in frame.winfo_children():
    w.destroy()
  bb.clear()
  ii.clear()
  for c in range(0,itemcount):
    if scht:
      bb.append(tk.Button(frame,text=scht))
    else:
      bb.append(tk.Button(frame,text="QwQ"))
    bb[c].grid(row=0+int(c/columncount)*2,column=c%columncount)
    ii.append(tk.Label(frame,image=img))
    ii[c].grid(row=1+int(c/columncount)*2,column=c%columncount)
    ii[c].bind("<Enter>",imgbig)
    ii[c].bind("<Leave>",imgsml)
  window.update()
  canvas.config(scrollregion=(0,0,frame.winfo_width(),frame.winfo_height()))

def _on_mousewheel(event):
    canvas.yview_scroll(int(-1*(event.delta/120)), "units")
#--------------------------------------------------------------------------------

# size of image display box
w_box = 200
h_box = 200

itemcount=6
columncount =3
wsize_x = 840
wsize_y = 500
bb=[]
ii=[]
window = tk.Tk()

window.title('UItest')
window.geometry(str(wsize_x)+'x'+str(wsize_y))
window.configure(background='white')
window.resizable(width=0,height=0)
window.bind_all("<MouseWheel>",_on_mousewheel)

canvas=tk.Canvas(window,width=wsize_x,height=wsize_y-30,scrollregion=(0,0,0,0))
canvas.place(x = 0, y = 0) #放置canvas的位置
frame=tk.Frame(canvas)
frame.pack()
vbar=tk.Scrollbar(canvas,orient=tk.VERTICAL,command=canvas.yview)
vbar.place(x = wsize_x-20,width=20,height=wsize_y-30)
canvas.configure(yscrollcommand=vbar.set)

bottombla = tk.Frame(window)
bottombla.pack(side=tk.BOTTOM)

im=Image.open(r".\poorface.jpg")
imor=ImageTk.PhotoImage(im)
w, h = im.size  
im_resized = resize(w, h, w_box, h_box, im)  
img = ImageTk.PhotoImage(im_resized)
for c in range(0,itemcount):
  bb.append(tk.Button(frame,text="QwQ"))
  bb[c].grid(row=0+int(c/columncount)*2,column=c%columncount)
  ii.append(tk.Label(frame,image=img))
  ii[c].grid(row=1+int(c/columncount)*2,column=c%columncount)
  ii[c].bind("<Enter>",imgbig)
  ii[c].bind("<Leave>",imgsml)
window.update()
canvas.config(scrollregion=(0,0,frame.winfo_width(),frame.winfo_height()))


ree=tk.Button(bottombla,text="重整",command=recount)
ree.pack(side=tk.RIGHT)
ivar = tk.StringVar(window)
ivar.set(itemcount)
itemcountsp=tk.Spinbox(bottombla,from_=1,to=35,textvariable=ivar)
itemcountsp.pack(side=tk.RIGHT)
itemcountt=tk.Label(bottombla,text="總個數: ")
itemcountt.pack(side=tk.RIGHT)
cvar = tk.StringVar(window)
cvar.set(columncount)
columncountsp=tk.Spinbox(bottombla,from_=1,to=4,textvariable=cvar)
columncountsp.pack(side=tk.RIGHT)
columncountt=tk.Label(bottombla,text="每行個數(1-4): ")
columncountt.pack(side=tk.RIGHT)
searc=tk.Entry(bottombla)
searc.pack(side=tk.RIGHT)
searct=tk.Label(bottombla,text="SEARCH : ")
searct.pack(side=tk.RIGHT)

canvas.create_window((wsize_x/2,0),anchor=tk.N, window=frame)
# 運行主程式
window.mainloop()
