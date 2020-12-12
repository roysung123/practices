import tkinter as tk
import glob
from PIL import Image,ImageTk
import random
from os import startfile


#=======================================================================================
def randomrefresh():
    global n
    global bb
    global ii
    global mm
    global ivar
    vv = searchvar.get()
    #print(vv)
    try:
        bb.clear()
        ii.clear()
        mm.clear()
        for widget in frame.winfo_children():
            widget.destroy()
        colcount = int(cvar.get())
        if vv == "":
            moviecount = int(ivar.get())
            for c in range(0,int(moviecount)):
              n=random.randrange(0,len(movlist)-1)
              bb.append(tk.Button(frame,text=movlist[n].lstrip(".\movie\\"),height=5,wraplength = 190,anchor = tk.N,command=lambda n=n:playvid(n)))
              bb[c].grid(row=0+int(c/colcount)*2,column=c%colcount)
              if colcount > 1:
                  ii.append(tk.Label(frame,image=imglist[n]))
                  ii[c].grid(row=1+int(c/colcount)*2,column=c%colcount)
                  ii[c].bind("<Enter>",lambda event,n=n,c=c:imgbig(event,n,c))
                  ii[c].bind("<Leave>",lambda event,n=n,c=c:imgsml(event,n,c))
              else:
                  ii.append(tk.Label(frame,image=orimglist[n]))
                  ii[c].grid(row=1+int(c/colcount)*2,column=c%colcount)
        else:
            moviecount = 0
            for c in range(0,len(movlist)-1):
              n=c
              if vv in movlist[n]:
                  bb.append(tk.Button(frame,text=movlist[n].lstrip(".\movie\\"),height=5,wraplength = 190,anchor = tk.N,command=lambda n=n:playvid(n)))
                  bb[moviecount].grid(row=0+int(moviecount/colcount)*2,column=moviecount%colcount)
                  if colcount > 1:
                      ii.append(tk.Label(frame,image=imglist[n]))
                      ii[moviecount].grid(row=1+int(moviecount/colcount)*2,column=moviecount%colcount)
                      ii[moviecount].bind("<Enter>",lambda event,n=n,c=moviecount:imgbig(event,n,c))
                      ii[moviecount].bind("<Leave>",lambda event,n=n,c=moviecount:imgsml(event,n,c))
                  else:
                      ii.append(tk.Label(frame,image=orimglist[n]))
                      ii[moviecount].grid(row=1+int(moviecount/colcount)*2,column=moviecount%colcount)
                  moviecount+=1
    except ValueError:
        print("無資料!")
    #print(moviecount)
    ivar.set(moviecount)
    window.update()
    canvas.config(scrollregion=(0,0,frame.winfo_width(),frame.winfo_height()))
#=======================================================================================
def playvid(n):
    print(str(n)+" "+str(movlist[n]))
    startfile(movlist[n])

def imgbig(event,n,c):
  event.widget.config(image=orimglist[n])
  window.update()
  canvas.config(scrollregion=(0,0,frame.winfo_width(),frame.winfo_height()))

def imgsml(event,n,c):
  event.widget.config(image=imglist[n])
  window.update()
  canvas.config(scrollregion=(0,0,frame.winfo_width(),frame.winfo_height()))

def _on_mousewheel(event):
    canvas.yview_scroll(int(-1*(event.delta/120)), "units")
#=======================================================================================

    
w_box = 200
h_box = 200
dirpat = r".\movie\*.*"#影片位址
movlist = glob.glob(dirpat)
imglist = []
orimglist = []
bb = []
ii = []
mm = []
moviecount = 1
colcount = 1

wsize_x = 840
wsize_y = 650

window = tk.Tk()
window.title('mydist')
window.geometry(str(wsize_x)+'x'+str(wsize_y))
window.configure(background='white')
window.resizable(width=0,height=0)
window.bind_all("<MouseWheel>",_on_mousewheel)
#=======================================================================================
canvas=tk.Canvas(window,width=wsize_x,height=wsize_y-30,scrollregion=(0,0,0,wsize_y))
canvas.place(x = 0, y = 0) #放置canvas的位置
frame=tk.Frame(canvas)
frame.place(width=wsize_x-40, height=wsize_y-30)
vbar=tk.Scrollbar(canvas,orient=tk.VERTICAL)
vbar.place(x = wsize_x-20,width=20,height=wsize_y-30)
vbar.configure(command=canvas.yview)
canvas.config(yscrollcommand=vbar.set)
bottombla = tk.Frame(window)
bottombla.pack(side=tk.BOTTOM)
#=======================================================================================
tot_count = 0
for i in movlist:
    imaddr = glob.glob(r".\cover\*"+i.split("[")[1].split("]")[0]+r".*")#封面位址
    try:
        im=Image.open(imaddr[0])
    except IndexError:
        print(i)
        imaddr = glob.glob(r".\cover\poorface.jpg")#無封面
        im=Image.open(imaddr[0])
    w, h = im.size
    orimglist.append(ImageTk.PhotoImage(im))
    im.thumbnail((w_box,h_box))
    imglist.append(ImageTk.PhotoImage(im))
    tot_count+=1
    print("Loading...("+str(tot_count)+"/"+str(len(movlist))+")")
#=================================================1
try:
    for c in range(0,int(moviecount)):
        n=random.randrange(0,len(movlist)-1)
        bb.append(tk.Button(frame,text=movlist[n].lstrip(".\movie\\"),height=5,wraplength = 190,anchor = tk.N,command=lambda n=n:playvid(n)))
        bb[c].grid(row=0+int(c/colcount)*2,column=c%colcount)
        if colcount > 1:
            ii.append(tk.Label(frame,image=imglist[n]))
            ii[c].grid(row=1+int(c/colcount)*2,column=c%colcount)
            ii[c].bind("<Enter>",lambda event,n=n,c=c:imgbig(event,n,c))
            ii[c].bind("<Leave>",lambda event,n=n,c=c:imgsml(event,n,c))
        else:
            ii.append(tk.Label(frame,image=orimglist[n]))
            ii[c].grid(row=1+int(c/colcount)*2,column=c%colcount)
except ValueError:
    print("無資料!")
window.update()
canvas.config(scrollregion=(0,0,frame.winfo_width(),frame.winfo_height()))
#=======================================================================================
ree=tk.Button(bottombla,text="重整",command=randomrefresh)
ree.pack(side=tk.RIGHT)
ivar = tk.StringVar(window)
ivar.set(moviecount)
itemcountsp=tk.Spinbox(bottombla,from_=1,to=35,textvariable=ivar)
itemcountsp.pack(side=tk.RIGHT)
itemcountt=tk.Label(bottombla,text="總個數: ")
itemcountt.pack(side=tk.RIGHT)
cvar = tk.StringVar(window)
cvar.set(colcount)
columncountsp=tk.Spinbox(bottombla,from_=1,to=4,textvariable=cvar)
columncountsp.pack(side=tk.RIGHT)
columncountt=tk.Label(bottombla,text="每行個數(1-4): ")
columncountt.pack(side=tk.RIGHT)
searchvar = tk.StringVar()
searc=tk.Entry(bottombla,textvariable=searchvar)
searc.pack(side=tk.RIGHT)
searct=tk.Label(bottombla,text="搜尋 : ")
searct.pack(side=tk.RIGHT)
canvas.create_window((wsize_x/2,0),anchor=tk.N, window=frame)


# 運行主程式
window.mainloop()
