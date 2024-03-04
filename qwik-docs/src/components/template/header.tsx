import { component$ } from "@builder.io/qwik";
import GitHubIcon from "./git-hub-icon";
import { Logo } from "./logo";
// import { Logomark } from "./logo";
import MobileNavigation from "./mobile-navigation";
export default component$(() => {
  //   let [isScrolled, setIsScrolled] = useState(false)

  //   useEffect$(() => {
  //     function onScroll() {
  //       setIsScrolled(window.scrollY > 0)
  //     }
  //     onScroll()
  //     window.addEventListener('scroll', onScroll, { passive: true })
  //     return () => {
  //       window.removeEventListener('scroll', onScroll)
  //     }
  //   }, [])

  return (
    <header
      class="sticky top-0 z-50 flex flex-none flex-wrap items-center justify-between bg-white px-4 lg:py-5 py-1
      shadow-md shadow-slate-900/5 transition duration-500 sm:px-4 lg:px-6 dark:shadow-none dark:bg-transparent">
      <div class="mx-auto w-full max-w-8xl justify-center sm:px-2 lg:px-6 xl:px-8">
        <div class="lg:hidden flex">          
          <MobileNavigation />          
        </div>
        <div class="hidden lg:flex relative">
          <div class="flex-none">
            <a href="/" aria-label="Home page">
              <Logo class="hidden h-9 w-auto fill-slate-700 lg:block dark:fill-sky-100 text-2xl " />
            </a>          
            </div>
          <div class="flex-grow">            
          </div>
          <div class="flex-none pt-2">
            <a href="https://github.com/bitcobblers/ZeUnit/" target="_blank" class="group" aria-label="ZeUnit repository on GitHub">
              <GitHubIcon class="h-6 w-6 fill-slate-400 group-hover:fill-slate-500 dark:group-hover:fill-slate-300" />
            </a>
          </div>
        </div>
      </div>
    </header>
  )
});